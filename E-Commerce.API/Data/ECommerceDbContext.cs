using E_Commerce.API.Repositories.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;

namespace E_Commerce.API.Data
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductCategories>().HasOne(p => p.Product).WithMany().OnDelete(DeleteBehavior.ClientSetNull);

            var productCategories = new List<ProductCategories>()
            {
                new ProductCategories()
                {
                    Id = Guid.Parse("16f5c4a1-37ec-415b-8f04-e04901bed64c"),
                    ProductId = Guid.Parse("4BD9F24D-8F1C-4124-8B63-3A13196199B0"),
                    CategoryId = Guid.Parse("28DCC80F-FAD6-472B-AD40-4E1DDB175612")
                },
                new ProductCategories()
                {
                    Id = Guid.Parse("4ae2f6d8-1501-462e-a496-b1fec213fa95"),
                    ProductId = Guid.Parse("4BD9F24D-8F1C-4124-8B63-3A13196199B0"),
                    CategoryId = Guid.Parse("8B51EE91-C293-4E05-8D8B-9FBEF15ADAE4")
                },
                new ProductCategories()
                {
                    Id = Guid.Parse("dae8721c-8b4f-4e4c-bec5-0ec5e299ab4f"),
                    ProductId = Guid.Parse("266A9FD0-B089-4230-AC51-4560F83F58E5"),
                    CategoryId = Guid.Parse("2BBD6301-A90F-4DC5-B02F-58BE57BE4F17")
                },
                new ProductCategories()
                {
                    Id = Guid.Parse("2031fdc5-1993-48af-a725-7e4800156646"),
                    ProductId = Guid.Parse("CA451DC9-13B7-4F80-9122-576183146C3E"),
                    CategoryId = Guid.Parse("F7521B70-9B2D-41F1-88D6-6B3AC1D1E085")
                },
                new ProductCategories()
                {
                    Id = Guid.Parse("d64723a7-7e2a-4404-a1df-f6a15d2752cd"),
                    ProductId = Guid.Parse("CA451DC9-13B7-4F80-9122-576183146C3E"),
                    CategoryId = Guid.Parse("DF12A7FC-670C-4220-9F4A-6E93993EEE26")
                },
                new ProductCategories()
                {
                    Id = Guid.Parse("ca98e177-383f-4617-877b-b88d34a60805"),
                    ProductId = Guid.Parse("6160BDE1-34EA-4680-B8BC-62A960AEB15C"),
                    CategoryId = Guid.Parse("A7CB98F0-CFF6-4D74-A1D5-184033271C18")
                },
                new ProductCategories()
                {
                    Id = Guid.Parse("6055b824-7292-4a19-a406-d5e78927a80f"),
                    ProductId = Guid.Parse("6160BDE1-34EA-4680-B8BC-62A960AEB15C"),
                    CategoryId = Guid.Parse("EBB74345-CB5C-4248-AD6E-7C4466129DB1")
                },
                new ProductCategories()
                {
                    Id = Guid.Parse("2480f729-a5f9-49ad-893a-46c16297d842"),
                    ProductId = Guid.Parse("34F6F251-0B70-4535-89F6-6C8CEAD48531"),
                    CategoryId = Guid.Parse("8B51EE91-C293-4E05-8D8B-9FBEF15ADAE4")
                },
                new ProductCategories()
                {
                    Id = Guid.Parse("15a31c0c-90dc-4644-9937-b141cd1f6a40"),
                    ProductId = Guid.Parse("34F6F251-0B70-4535-89F6-6C8CEAD48531"),
                    CategoryId = Guid.Parse("28DCC80F-FAD6-472B-AD40-4E1DDB175612")
                },
                new ProductCategories()
                {
                    Id = Guid.Parse("1ac24ac7-2cd0-4938-bab7-2ecde095c376"),
                    ProductId = Guid.Parse("1CF2A3DA-EE1C-426A-A97A-8CD603768771"),
                    CategoryId = Guid.Parse("914EF09E-B3AA-4E3F-8B2C-FB08CB5D7DA7")
                },
                new ProductCategories()
                {
                    Id = Guid.Parse("267100eb-4130-4ca7-b9d4-91c09de46b89"),
                    ProductId = Guid.Parse("1CF2A3DA-EE1C-426A-A97A-8CD603768771"),
                    CategoryId = Guid.Parse("914EF09E-B3AA-4E3F-8B2C-FB08CB5D7DA7")
                },
                new ProductCategories()
                {
                    Id = Guid.Parse("c703843d-0a13-4a7b-b4d8-ed5563c0436b"),
                    ProductId = Guid.Parse("1D31B89E-5456-4476-B3E0-A6D25CE795ED"),
                    CategoryId = Guid.Parse("69BF082D-ED81-47FA-8D48-BF2F0FFA90C5")
                },
                new ProductCategories()
                {
                    Id = Guid.Parse("24785e18-a10e-4f03-9b6f-8a2a1e4b3db2"),
                    ProductId = Guid.Parse("1D31B89E-5456-4476-B3E0-A6D25CE795ED"),
                    CategoryId = Guid.Parse("69BF082D-ED81-47FA-8D48-BF2F0FFA90C5")
                },
                new ProductCategories()
                {
                    Id = Guid.Parse("8bc18ea6-d216-4ceb-9928-a75190a21246"),
                    ProductId = Guid.Parse("88431346-6E71-4C97-B2E9-B06761230F33"),
                    CategoryId = Guid.Parse("914EF09E-B3AA-4E3F-8B2C-FB08CB5D7DA7")
                },
                new ProductCategories()
                {
                    Id = Guid.Parse("3dc85019-1a68-44d8-8b57-d05bd3b9b209"),
                    ProductId = Guid.Parse("88431346-6E71-4C97-B2E9-B06761230F33"),
                    CategoryId = Guid.Parse("914EF09E-B3AA-4E3F-8B2C-FB08CB5D7DA7")
                },
                new ProductCategories()
                {
                    Id = Guid.Parse("02407c5a-6d82-4871-a0d0-3caef0788b6f"),
                    ProductId = Guid.Parse("B38DB405-80FA-4347-9359-BFC513E578A8"),
                    CategoryId = Guid.Parse("DF12A7FC-670C-4220-9F4A-6E93993EEE26")
                },
            };
            modelBuilder.Entity<ProductCategories>().HasData(productCategories);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
    }
    
}
