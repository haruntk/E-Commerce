using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;

namespace E_Commerce.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<Guid> CreateAsync(AddProductRequestDto addProductRequest);
        public Task<Product?> DeleteAsync(Guid id);
        public Task<Product?> UpdateByIdAsync(Guid id, UpdateProductRequestDto updateProductRequestDto);
        public Task<List<Product>> GetAllAsync();
        public Task<Product> GetByIdAsync(Guid id);
    }
}
