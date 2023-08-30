using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;

namespace E_Commerce.API.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task<Guid> CreateAsync(OrderRequestDto orderRequestDto, string id);
        public Task<List<Order>?> GetByIdAsync (Guid userId);
    }
}
