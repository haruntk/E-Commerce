using AutoMapper;
using E_Commerce.API.Data;
using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;
using E_Commerce.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceDbContext dbContext;
        private readonly IMapper mapper;

        public ProductRepository(ECommerceDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<List<Product>> GetListByIdsAsync(List<Guid> ids)
        {
            return await dbContext.Products.Where(x=> ids.Contains(x.Id)).ToListAsync();
        }

        public async void CreateAsync(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Product?> DeleteAsync(Guid id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return null;
            }
            dbContext.Remove(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            var product = dbContext.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }

        public async void UpdateByIdAsync(Product product)
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
