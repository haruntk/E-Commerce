using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;

namespace E_Commerce.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetListByIdsAsync(List<Guid> ids);
        public void CreateAsync(Product product);
        public Task<Product?> DeleteAsync(Guid id);
        public void UpdateByIdAsync(Product product);
        public Task<List<Product>> GetAllAsync(int skip, int limit);
        public Task<Product> GetByIdAsync(Guid id);
    }
}
