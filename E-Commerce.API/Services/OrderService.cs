using AutoMapper;
using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;
using E_Commerce.API.Repositories.Interfaces;
using E_Commerce.API.Services.Interfaces;

namespace E_Commerce.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
            this.productRepository = productRepository;
        }
        public async Task<ApiResponseDto<Guid>> CreateAsync(OrderRequestDto orderRequestDto, string id)
        {
            var products = await productRepository.GetAllAsync();
            var orderItems = mapper.Map<List<OrderItem>>(orderRequestDto);
            var orderId = Guid.NewGuid();
            double totalPrice = 0;
            foreach (var item in orderItems)
            {
                var product = products.FirstOrDefault(x => x.Id == item.ProductId);
                if (product == null || product.Quantity < item.Quantity || item.Quantity == 0)
                {
                    return new ApiResponseDto<Guid>
                    {
                        Data = item.ProductId,
                        IsSuccess = false,
                        Message = "Product Does Not Exist OR Out Of Stock"
                    };
                }
                item.UnitPrice = product.Price * item.Quantity;
                item.OrderId = orderId;
                item.Id = Guid.NewGuid();
                totalPrice += item.UnitPrice;
                product.Quantity -= item.Quantity;
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
            return new ApiResponseDto<Guid>
            {
                Data = orderId,
                IsSuccess = true,
                Message = "Order has been created"
            };
        }
        public async Task<ApiResponseDto<List<OrderDto>>> GetByIdAsync(Guid userId)
        {
            var orders = await orderRepository.GetByIdAsync(userId);
            var ordersDto = mapper.Map<List<OrderDto>>(orders);
            if (ordersDto == null)
            {
                return new ApiResponseDto<List<OrderDto>>
                {
                    IsSuccess = false,
                    Message = "Order not found!"
                };
            }
            return new ApiResponseDto<List<OrderDto>>
            {
                Data = ordersDto,
                IsSuccess = true,
                Message = "Order found."
            };
        }
    }
}
