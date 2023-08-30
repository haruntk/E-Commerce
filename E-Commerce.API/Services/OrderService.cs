using AutoMapper;
using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories.Interfaces;
using E_Commerce.API.Services.Interfaces;

namespace E_Commerce.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }
        public async Task<ApiResponseDto<Guid>> CreateAsync(OrderRequestDto orderRequestDto, string id)
        {
            var orderId = await orderRepository.CreateAsync(orderRequestDto, id);
            if (orderId == Guid.Empty)
            {
                return new ApiResponseDto<Guid>
                {
                    IsSuccess = false,
                    Message = "Order could not be created."
                };
            }
            return new ApiResponseDto<Guid>
            {
                Data = orderId,
                IsSuccess = true,
                Message = "Order has been created"
            };
        }

        public async Task<ApiResponseDto<List<OrderDto>>> GetByIdAsync(Guid userId)
        {
            var orders = await orderRepository.GetByIdAsync(userId);
            var ordersDto = mapper.Map<List<OrderDto>>(orders);
            if (ordersDto == null)
            {
                return new ApiResponseDto<List<OrderDto>>
                {
                    IsSuccess = false,
                    Message = "Order not found!"
                };
            }
            return new ApiResponseDto<List<OrderDto>>
            {
                Data = ordersDto,
                IsSuccess = true,
                Message = "Order found."
            };
        }
    }
}
