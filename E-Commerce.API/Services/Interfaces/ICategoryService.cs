using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Entities;

namespace E_Commerce.API.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<ApiResponseDto<List<CategoryDto>>> GetAllAsync();
        public Task<ApiResponseDto<CategoryDto>> AddAsync(AddCategoryRequestDto addCategoryRequestDto);
        public Task<ApiResponseDto<CategoryDto>> DeleteAsync(Guid id);
    }
}
