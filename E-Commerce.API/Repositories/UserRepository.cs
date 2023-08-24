using AutoMapper;
using E_Commerce.API.Data;
using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;
using E_Commerce.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ECommerceAuthDbContext dbContext;
        private readonly IMapper mapper;

        public UserRepository(ECommerceAuthDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<List<IdentityUser>> GetAllFromDatabase()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<UserDto> GetByIdFromDatabase(Guid id)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id.ToString());
            if (existingUser == null)
            {
                return null;
            }
            return mapper.Map<UserDto>(existingUser);
        }
    }
}
