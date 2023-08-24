using E_Commerce.API.Data;
using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;
using E_Commerce.API.Repositories.Interfaces;

namespace E_Commerce.API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ECommerceDbContext dbContext;

        public OrderRepository(ECommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<OrderDto>> GetOrdersFromDatabase(Guid id)
        {
            
        }

        public async Task<Order> Order(Guid orderId, Guid productId, int quantity)
        {
            var order = dbContext.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                return null;
            }
            var productPrice = dbContext.Products.FirstOrDefault(p => p.Id == productId).Price;
            var unitPrice = productPrice * quantity;
            var orderItem = new OrderItem();
            orderItem.Id = Guid.NewGuid();
            orderItem.ProductId = productId;
            orderItem.Quantity = quantity;
            orderItem.OrderId = orderId;
            orderItem.UnitPrice = unitPrice;
            order.TotalPrice += unitPrice;
            await dbContext.OrderItems.AddAsync(orderItem);
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
        }
    }
}
