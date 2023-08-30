using E_Commerce.API.Models.DTO;

namespace E_Commerce.API.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<ApiResponseDto<Guid>> CreateAsync(OrderRequestDto orderRequestDto, string id);
        public Task<ApiResponseDto<List<OrderDto>>> GetByIdAsync(Guid userId);
    }
}
