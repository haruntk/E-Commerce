using E_Commerce.API.Repositories.Entities;

namespace E_Commerce.API.Models.DTO
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public double TotalPrice { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
