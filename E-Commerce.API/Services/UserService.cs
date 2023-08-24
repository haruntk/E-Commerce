using AutoMapper;
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
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository, IUserRepository userRepository,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<ApiResponseDto<List<UserDto>>> GetAllAsync()
        {
            var users = await userRepository.GetAllFromDatabase();
            var usersDto = mapper.Map<List<UserDto>>(users);
            var apiResponse = new ApiResponseDto<List<UserDto>>();
            apiResponse.IsSuccess = false;
            apiResponse.Message = "Something Went Wrong";

            if (usersDto != null)
            {
                apiResponse.Data = usersDto;
                apiResponse.IsSuccess = true;
                apiResponse.Message = "Transaction Completed Successfully";
                return apiResponse;
            }

            return apiResponse;
        }

        public async Task<ApiResponseDto<UserDto>> GetByIdAsync(Guid id)
        {
            var userDto = await userRepository.GetByIdFromDatabase(id);
            var apiResponse = new ApiResponseDto<UserDto>();
            apiResponse.IsSuccess = false;
            apiResponse.Message = "User Not Found";
            if (userDto != null)
            {
                apiResponse.Data = userDto;
                apiResponse.IsSuccess = true;
                apiResponse.Message = "User Found";
                return apiResponse;
            }

            return apiResponse;
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
