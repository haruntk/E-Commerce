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

        public async Task<int> CreateAsync(Order order, List<OrderItem> orderItems)
        {
            var trans = await dbContext.Database.BeginTransactionAsync();
            try
            {
                await dbContext.Orders.AddAsync(order);
                await dbContext.OrderItems.AddRangeAsync(orderItems);
                await trans.CommitAsync();
                return await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Order>?> GetByIdAsync(Guid userId)
        {
            var orders = dbContext.Orders
                         .Where(o => o.UserId == userId)
                         .ToList();
            return orders;
        }
    }
}
