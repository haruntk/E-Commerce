using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;

namespace E_Commerce.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<ProductDto> CreateAsyncToDatabase(AddProductRequestDto addProductRequest);
        public Task<Product?> DeleteAsyncFromDatabase(Guid id);
        public Task<ProductDto?> UpdateByIdToDatabase(Guid id, UpdateProductRequestDto updateProductRequestDto);
        public Task<List<Product>> GetAllFromDatabase();
        public Task<ProductDto> GetByIdFromDatabase(Guid id);
    }
}
