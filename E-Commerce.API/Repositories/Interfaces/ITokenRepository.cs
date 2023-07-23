using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace E_Commerce.API.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
