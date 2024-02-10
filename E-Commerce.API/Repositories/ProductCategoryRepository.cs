using Dapper;
using E_Commerce.API.Data;
using E_Commerce.API.Repositories.Entities;
using E_Commerce.API.Repositories.Interfaces;
using Microsoft.Data.SqlClient;

namespace E_Commerce.API.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ECommerceDbContext dbContext;
        private readonly IConfiguration configuration;

        public ProductCategoryRepository(ECommerceDbContext dbContext, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.dbContext = dbContext;
        }
        public async Task<int> Create(List<ProductCategory> productCategories)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("ECommerceConnectionString"));
            string sql = "INSERT INTO ProductCategories (Id, CategoryId, ProductId, IsMain) VALUES (@Id, @CategoryId, @ProductId, @IsMain)";
            return await connection.ExecuteAsync(sql, productCategories);
            //await dbContext.ProductCategories.AddRangeAsync(productCategories);
            //return await dbContext.SaveChangesAsync();
        }
    }
}
