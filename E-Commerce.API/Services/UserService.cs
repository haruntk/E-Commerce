using AutoMapper;
using Azure;
using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Interfaces;
using E_Commerce.API.Services.Interfaces;
using E_Commerce.API.Validations;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ITokenRepository tokenRepository;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;


        public UserService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ITokenRepository tokenRepository, IUserRepository userRepository,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenRepository = tokenRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<ApiResponseDto<List<UserDto>>> GetAllAsync()
        {
            var users = await userRepository.GetAllAsync();
            var usersDto = mapper.Map<List<UserDto>>(users);
            if (usersDto != null)
            {
                return new ApiResponseDto<List<UserDto>>
                {
                    Data = usersDto,
                    IsSuccess = true,
                    Message = "Transaction Completed Successfully"
                };
            }
            return new ApiResponseDto<List<UserDto>>
            {
                IsSuccess = false,
                Message = "Something Went Wrong"
            };
        }

        public async Task<ApiResponseDto<UserDto>> GetByIdAsync(Guid id)
        {
            var user = await userRepository.GetByIdAsync(id);
            var userDto = mapper.Map<UserDto>(user);

            if (userDto != null)
            {
                return new ApiResponseDto<UserDto>
                {
                    Data = userDto,
                    IsSuccess = true,
                    Message = "User Found"
                };
            }

            return new ApiResponseDto<UserDto>
            {
                IsSuccess = false,
                Message = "User Not Found"
            };
        }

        public async Task<ApiResponseDto<LoginResponseDto?>> Login(LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);
            var validator = new LoginValidator();
            var result = await validator.ValidateAsync(loginRequestDto);
            if (!result.IsValid)
            {
                return new ApiResponseDto<LoginResponseDto?>
                {
                    IsSuccess = false,
                    Message = result.Errors.FirstOrDefault(x=> true).ToString()
                };
            }
            if (user == null)
            {
                return new ApiResponseDto<LoginResponseDto?>
                {
                    IsSuccess = false,
                    Message = result.Errors.FirstOrDefault(x=> true).ToString()
                };
            }
            
            var checkPasswordResultSuccess = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (!checkPasswordResultSuccess)
            {
                return new ApiResponseDto<LoginResponseDto?>
                {
                    IsSuccess = false,
                    Message = result.Errors.FirstOrDefault(x=> true).ToString()
                };
            }
            var roles = await userManager.GetRolesAsync(user);
            if (roles == null)
            {
                return new ApiResponseDto<LoginResponseDto?>
                {
                    IsSuccess = false,
                    Message = result.Errors.FirstOrDefault(x => true).ToString()
                };
            }

            var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());
            return new ApiResponseDto<LoginResponseDto?>
            {
                Data = new LoginResponseDto { JwtToken = jwtToken },
                IsSuccess = true,
                Message = "Login successful"
            };
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<ApiResponseDto<RegisterResponseDto?>> Register(RegisterRequestDto registerRequestDto)
        {
            var validator = new RegisterValidator();
            var result = await validator.ValidateAsync(registerRequestDto);
            if (result.IsValid)
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
                            return new ApiResponseDto<RegisterResponseDto?>
                            {
                                Data = new RegisterResponseDto
                                {
                                    UserName = registerRequestDto.Username,
                                    Password = registerRequestDto.Password
                                },
                                IsSuccess = true,
                                Message = "Registered! Please Login!"
                            };
                        }
                    }
                }
            }
            return new ApiResponseDto<RegisterResponseDto?>
            {
                IsSuccess = false,
                Message = result.Errors.FirstOrDefault(x => true).ToString()
            };
        }
    }
}
