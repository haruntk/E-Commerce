using E_Commerce.API.Models.DTO;

namespace E_Commerce.API.Services.Interfaces
{
    public interface IUserService
    {
        public Task<ApiResponseDto<RegisterResponseDto?>> Register(RegisterRequestDto registerRequestDto);
        public Task<ApiResponseDto<LoginResponseDto?>> Login(LoginRequestDto loginRequestDto);
    }
}
