using AutoMapper;
using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;
using E_Commerce.API.Repositories.Interfaces;
using E_Commerce.API.Services.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace E_Commerce.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;
        private readonly IDistributedCache distributedCache;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IProductRepository productRepository, 
            IDistributedCache distributedCache)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
            this.productRepository = productRepository;
            this.distributedCache = distributedCache;
        }
        public async Task<ApiResponseDto<Guid>> CreateAsync(OrderRequestDto orderRequestDto, string id)
        {
            var orderItems = mapper.Map<List<OrderItem>>(orderRequestDto.OrderItems);
            var orderId = Guid.NewGuid();
            double totalPrice = 0;
            var productIds = orderRequestDto.OrderItems.Select(x => x.ProductId).ToList();
            var products = await productRepository.GetListByIdsAsync(productIds);
            foreach (var item in orderItems)
            {
                var product = products.FirstOrDefault(x => x.Id == item.ProductId);
                if (product == null || product.Stock < item.Quantity || item.Quantity == 0)
                {
                    return new ApiResponseDto<Guid>
                    {
                        Data = item.ProductId,
                        IsSuccess = false,
                        Message = "Product Does Not Exist OR Out Of Stock"
                    };
                }
                item.UnitPrice = product.Price;
                item.OrderId = orderId;
                item.Id = Guid.NewGuid();
                totalPrice += item.UnitPrice * item.Quantity;
                product.Stock -= item.Quantity;
                productRepository.UpdateByIdAsync(product);
            }
            var order = new Order
            {
                Id = orderId,
                CreatedDate = DateTime.Now,
                Status = Status.PREPARING,
                TotalPrice = totalPrice,
                UserId = Guid.Parse(id),
            };
            var affectedRows = await orderRepository.CreateAsync(order, orderItems);
            if (affectedRows == 0)
            {
                return new ApiResponseDto<Guid>
                {
                    IsSuccess = false,
                    Message = "Order could not be created."
                };
            }
            await distributedCache.RemoveAsync($"member-{id}");
            return new ApiResponseDto<Guid>
            {
                Data = orderId,
                IsSuccess = true,
                Message = "Order has been created"
            };
        }
        public async Task<ApiResponseDto<List<OrderDto>>> GetByIdAsync(Guid userId)
        {
            string key = $"member-{userId}";
            string cachedMember = await distributedCache.GetStringAsync(key);
            List<OrderDto>? ordersDto;

            if (string.IsNullOrEmpty(cachedMember))
            {
                var orders = await orderRepository.GetByIdAsync(userId);
                ordersDto = mapper.Map<List<OrderDto>>(orders);
                if (ordersDto == null)
                {
                    return new ApiResponseDto<List<OrderDto>>
                    {
                        IsSuccess = false,
                        Message = "Order not found!"
                    };
                }
                var groupedOrders = ordersDto.GroupBy(o => o.Id)
                                             .Select(group =>
                                             {
                                                 var order = group.First();
                                                 order.OrderItems = group.SelectMany(o => o.OrderItems).ToList();
                                                 return order;
                                             });
                ordersDto = groupedOrders.ToList();
                await distributedCache.SetStringAsync(key, JsonSerializer.Serialize(ordersDto), new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(30)
                });
                return new ApiResponseDto<List<OrderDto>>
                {
                    Data = ordersDto,
                    IsSuccess = true,
                    Message = "Order found."
                };
            }
            ordersDto = JsonSerializer.Deserialize<List<OrderDto>>(cachedMember);
            return new ApiResponseDto<List<OrderDto>>
            {
                Data = ordersDto,
                IsSuccess = true,
                Message = "Order found with Redis Cache."
            };
        }
    }
}
