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

        public async Task<Guid> CreateAsync(AddProductRequestDto addProductRequest)
        {
            var mainCategoryId = Guid.Empty;
            foreach (var item in addProductRequest.ProductCategories)
            {
                if (item.IsMain)
                {
                    mainCategoryId = item.CategoryId;
                }
            }
            var product = mapper.Map<Product>(addProductRequest);
            product.Id = Guid.NewGuid();
            product.MainCategoryId = mainCategoryId;
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return product.Id;
        }

        public async Task<Product?> DeleteAsync(Guid id)
        {
            var existingProduct = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (existingProduct == null)
            {
                return null;
            }
            dbContext.Remove(existingProduct);
            await dbContext.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            var existingProduct = dbContext.Products.FirstOrDefault(x => x.Id == id);
            if (existingProduct == null)
            {
                return null;
            }
            return existingProduct;
        }

        public async Task<Product?> UpdateByIdAsync(Guid id, UpdateProductRequestDto updateProductRequestDto)
        {
            var existingProduct = dbContext.Products.FirstOrDefault(x => x.Id == id);
            if (existingProduct == null)
            {
                return null;
            }
            existingProduct.Quantity = updateProductRequestDto.Quantity;
            existingProduct.Price = updateProductRequestDto.Price;
            existingProduct.MainCategoryId = updateProductRequestDto.MainCategoryId;
            existingProduct.Name = updateProductRequestDto.Name;
            await dbContext.SaveChangesAsync();
            return existingProduct;
        }
    }
}
