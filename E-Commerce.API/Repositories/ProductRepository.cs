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
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public ProductRepository(ECommerceDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<List<Product>> GetListByIdsAsync(List<Guid> ids)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("ECommerceConnectionString"));
            string sql = "SELECT * FROM Products WHERE Id IN @Ids";
            var products = await connection.QueryAsync<Product>(sql, new { Ids = ids });
            return products.ToList();
            //return await dbContext.Products.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async void CreateAsync(Product product)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("ECommerceConnectionString"));
            var sql = "INSERT INTO Products (Id, Name, Price, Quantity, MainCategoryId) VALUES (@Id, @Name, @Price, @Stock, @MainCategoryId)";
            await connection.ExecuteAsync(sql, product);
            //await dbContext.Products.AddAsync(product);
            //await dbContext.SaveChangesAsync();
        }

        public async Task<Product?> DeleteAsync(Guid id)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("ECommerceConnectionString"));
            var sqlDeleteP = "DELETE FROM Products WHERE Id = @Id";
            var sqlDeleteC = "DELETE FROM ProductCategories WHERE ProductId = @Id";
            await connection.ExecuteAsync(sqlDeleteC, new { Id = id });
            await connection.ExecuteAsync(sqlDeleteP, new { Id = id });
            //var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            //if (product == null)
            //{
            //    return null;
            //}
            //dbContext.Remove(product);
            //await dbContext.SaveChangesAsync();
            return null;
        }

        public async Task<List<Product>> GetAllAsync(int offset, int limit)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("ECommerceConnectionString"));
            string sql = "SELECT * FROM Products ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
            var products = await connection.QueryAsync<Product>(sql, new { Offset = offset, PageSize = limit });
            return products.ToList();
            // await dbContext.Products.AsQueryable().Skip(offset).Take(limit).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("ECommerceConnectionString"));
            string sql = "SELECT * FROM Products Where Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
            //var product = dbContext.Products.FirstOrDefault(x => x.Id == id);
            //return product;
        }

        public async void UpdateByIdAsync(Product product)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("ECommerceConnectionString"));
            string sql = "UPDATE Products SET Name = @Name, Price = @Price, Quantity = @Stock" +
                ", MainCategoryId = @MainCategoryId WHERE Id = @Id";
            await connection.ExecuteAsync(sql, product);
            //await dbContext.SaveChangesAsync();
        } 
    }
}
