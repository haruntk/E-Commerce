namespace E_Commerce.API.Models.DTO
{
    public class OrderRequestDto
    {
        public List<OrderItemRequestDto> OrderItems { get; set; }
    }
    public class OrderItemRequestDto
    {
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}
