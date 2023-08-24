namespace E_Commerce.API.Models.DTO
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
    }
}
