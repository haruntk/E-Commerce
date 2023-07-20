using E_Commerce.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Repositories.Interfaces
{
    public interface IRegisterService
    {
        public Task<RegisterResponseDto> Register(RegisterRequestDto registerRequestDto);
    }
}
