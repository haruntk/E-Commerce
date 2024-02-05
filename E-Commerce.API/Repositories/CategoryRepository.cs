using AutoMapper;
using Dapper;
using E_Commerce.API.Data;
using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;
using E_Commerce.API.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ECommerceDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public CategoryRepository(ECommerceDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await dbContext.Categories.ToListAsync();
        }
        public async void DeleteAsync(Category category)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("ECommerceConnectionString"));
            var sqlDeleteP = "DELETE FROM Categories WHERE Id = @Id";
            var sqlDeleteC = "DELETE FROM ProductCategories WHERE CategoryId = @Id";
            await connection.ExecuteAsync(sqlDeleteC, new { Id = category.Id });
            await connection.ExecuteAsync(sqlDeleteP, new { Id = category.Id });
            //dbContext.Categories.Remove(category);
            //await dbContext.SaveChangesAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
