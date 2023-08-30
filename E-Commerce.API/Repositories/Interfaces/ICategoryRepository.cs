using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;

namespace E_Commerce.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllAsync();
        public Task<Category> CreateAsync(AddCategoryRequestDto addCategoryRequestDto);
        public Task<Category?> DeleteAsync(Guid id);
    }
}
