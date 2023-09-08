using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;

namespace E_Commerce.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllAsync();
        public Task<Category> CreateAsync(Category category);
        public void DeleteAsync(Category category);
        public Task<Category?> GetByIdAsync(Guid id);
    }
}
