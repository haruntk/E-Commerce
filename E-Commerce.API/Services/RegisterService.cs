using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<IdentityUser> userManager;

        public RegisterService(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<RegisterResponseDto> Register(RegisterRequestDto registerRequestDto)  
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
                    if (identityResult.Succeeded)
                    {
                        var registerResponse = new RegisterResponseDto
                        {
                            UserName = registerRequestDto.Username,
                            Password = registerRequestDto.Password
                        };
                        return registerResponse;
                    }
                }
            }
            return null;
        }
    }
}
