using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;

namespace E_Commerce.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllAsyncFromDatabase();
        public Task<CategoryDto> CreateAsyncToDatabase(AddCategoryRequestDto addCategoryRequestDto);
        public Task<Category?> DeleteAsyncFromDatabase(Guid id);
    }
}
