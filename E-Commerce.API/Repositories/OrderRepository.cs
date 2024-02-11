using AutoMapper;
using Dapper;
using E_Commerce.API.Data;
using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;
using E_Commerce.API.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace E_Commerce.API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ECommerceDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public OrderRepository(ECommerceDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            this.configuration = configuration;
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
            using (var connection = new SqlConnection(configuration.GetConnectionString("ECommerceConnectionString")))
            {
                string sql = @"SELECT o.Id, o.UserId, o.Status, o.CreatedDate, o.TotalPrice,
                                      oi.Id, oi.UnitPrice, oi.Quantity, oi.OrderId, oi.ProductId
                               FROM Orders o
                               INNER JOIN OrderItems oi ON o.Id = oi.OrderId";
                var orders = await connection.QueryAsync<Order, OrderItem, Order>(sql, (order, orderItem) =>
                {
                    if (order.OrderItems == null)
                        order.OrderItems = new List<OrderItem>();
                    order.OrderItems.Add(orderItem);
                    return order;
                }, splitOn: "Id");
                return orders.ToList();
            }
            //var orders = dbContext.Orders
            //             .Where(o => o.UserId == userId)
            //             .ToList();
            //return orders;
        }
    }
}
