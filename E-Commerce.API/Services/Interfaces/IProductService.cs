using E_Commerce.API.Models.DTO;

namespace E_Commerce.API.Services.Interfaces
{
    public interface IProductService
    {
        public Task<ApiResponseDto<List<ProductDto>>> GetAllAsync();
        public Task<ApiResponseDto<Guid>> AddAsync(AddProductRequestDto addProductRequestDto);
        public Task<ApiResponseDto<ProductDto>> DeleteAsync(Guid id);
        public Task<ApiResponseDto<ProductDto>> UpdateAsync(Guid id, UpdateProductRequestDto updateProductRequestDto);
        public Task<ApiResponseDto<ProductDto>> GetByIdAsync(Guid id);
    }
}
