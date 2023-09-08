using E_Commerce.API.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<IdentityUser>> GetAllAsync();
        public Task<IdentityUser?> GetByIdAsync(Guid id);
    }
}
