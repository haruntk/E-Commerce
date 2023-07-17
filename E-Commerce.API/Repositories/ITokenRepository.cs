using Microsoft.AspNetCore.Identity;

namespace E_Commerce.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
