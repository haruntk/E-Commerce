using E_Commerce.API.Data;
using E_Commerce.API.Repositories.Entities;
using E_Commerce.API.Repositories.Interfaces;

namespace E_Commerce.API.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ECommerceDbContext dbContext;

        public ProductCategoryRepository(ECommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> Create(List<ProductCategory> productCategories)
        {
            await dbContext.ProductCategories.AddRangeAsync(productCategories);
            return await dbContext.SaveChangesAsync();
        }
    }
}
