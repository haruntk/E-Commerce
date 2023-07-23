using AutoMapper;
using E_Commerce.API.Data;
using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;
using E_Commerce.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ECommerceDbContext dbContext;
        private readonly IMapper mapper;

        public CategoryRepository(ECommerceDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CategoryDto> CreateAsyncToDatabase(AddCategoryRequestDto addCategoryRequestDto)
        {
            var category = mapper.Map<Category>(addCategoryRequestDto);
            category.Id = Guid.NewGuid();
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return mapper.Map<CategoryDto>(category);
        }

        public async Task<List<Category>> GetAllAsyncFromDatabase()
        {
            return await dbContext.Categories.ToListAsync();
        }
        public async Task<Category?> DeleteAsyncFromDatabase(Guid id)
        {
            var existingCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCategory == null)
            {
                return null;
            }
            dbContext.Remove(existingCategory);
            await dbContext.SaveChangesAsync();
            return existingCategory;
        }
    }
}
