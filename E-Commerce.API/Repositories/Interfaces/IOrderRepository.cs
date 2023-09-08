using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;

namespace E_Commerce.API.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task<int> CreateAsync(Order order, List<OrderItem> orderItems);
        public Task<List<Order>?> GetByIdAsync (Guid userId);
    }
}
