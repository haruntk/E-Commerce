using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;

namespace E_Commerce.API.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task<OrderItem> Order(Guid productId, int quantity);
        public Task<List<OrderDto>> GetOrdersFromDatabase(Guid id);
    }
}
