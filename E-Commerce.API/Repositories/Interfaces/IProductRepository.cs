using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;

namespace E_Commerce.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public void CreateAsync(Product product);
        public Task<Product?> DeleteAsync(Guid id);
        public void UpdateByIdAsync(Product product);
        public Task<List<Product>> GetAllAsync();
        public Task<Product> GetByIdAsync(Guid id);
    }
}
