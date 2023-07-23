using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Interfaces;
using E_Commerce.API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public UserService(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }
        public async Task<ApiResponseDto<LoginResponseDto?>> Login(LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);

            var response = new ApiResponseDto<LoginResponseDto>();

            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        response.Data = new LoginResponseDto { JwtToken = jwtToken };

                        response.IsSuccess = true;
                        response.Message = "Login successful!";

                        return response;
                    }
                }
            }
            response.IsSuccess = false;
            response.Message = "Username or Password Incorrect!";

            return response;
        }

        public async Task<ApiResponseDto<RegisterResponseDto?>> Register(RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };
            var registerResponse = new ApiResponseDto<RegisterResponseDto>();

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        registerResponse.Data = new RegisterResponseDto
                        {
                            UserName = registerRequestDto.Username,
                            Password = registerRequestDto.Password
                        };

                        registerResponse.IsSuccess = true;
                        registerResponse.Message = "Registered! Please Login!";
                        return registerResponse;
                    }
                }
            }
            registerResponse.IsSuccess = false;
            registerResponse.Message = "Register Failed!";

            return registerResponse;
        }
    }
}
