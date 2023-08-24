using E_Commerce.API.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<IdentityUser>> GetAllFromDatabase();
        public Task<UserDto?> GetByIdFromDatabase(Guid id);
    }
}
