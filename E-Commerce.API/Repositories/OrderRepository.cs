using AutoMapper;
using E_Commerce.API.Data;
using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;
using E_Commerce.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ECommerceDbContext dbContext;
        private readonly IMapper mapper;

        public OrderRepository(ECommerceDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<Guid> CreateAsync(OrderRequestDto orderRequestDto, string id)
        {
            var products = await dbContext.Products.ToListAsync();
            var orderItems = mapper.Map<List<OrderItem>>(orderRequestDto.OrderItems);
            var orderId = Guid.NewGuid();
            double totalPrice = 0;
            foreach (var item in orderItems)
            {
                var existingProduct = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == item.ProductId);
                if (existingProduct == null || existingProduct.Quantity == 0)
                {
                    return Guid.Empty;
                }
                item.UnitPrice = existingProduct.Price * item.Quantity;
                item.OrderId = orderId;
                item.Id = Guid.NewGuid();
                totalPrice += item.UnitPrice;
                existingProduct.Quantity -= item.Quantity;
            }
            var order = new Order
            {
                Id = orderId,
                CreatedDate = DateTime.Now,
                Status = Status.PREPARING,
                TotalPrice = totalPrice,
                UserId = Guid.Parse(id),
            };
            await dbContext.OrderItems.AddRangeAsync(orderItems);
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return orderId;
        }

        public async Task<List<Order>?> GetByIdAsync(Guid userId)
        {
            var existingOrders = new List<Order>();
            foreach (var item in dbContext.Orders)
            {
                if (item.UserId == userId)
                {
                    existingOrders.Add(item);
                }
            }
            if (existingOrders == null)
            {
                return null;
            }
            return existingOrders;
        }
    }
}
