using E_Commerce.API.Models.DTO;

namespace E_Commerce.API.Repositories.Interfaces
{
    public interface ILoginService
    {
        public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    }
}
