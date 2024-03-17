using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.API.Data
{
    public class ECommerceAuthDbContext : IdentityDbContext
    {
        public ECommerceAuthDbContext(DbContextOptions<ECommerceAuthDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
     
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var userRoleId = "898e865e-9845-4490-ac49-a91a0d86e637";
            var adminRoleId = "c74e7ece-7000-40b7-b81d-02902cf85dc1";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId,
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                },
                new IdentityRole
                {
                    Id = adminRoleId,
                    ConcurrencyStamp= adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
