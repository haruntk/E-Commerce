namespace E_Commerce.API.Models.Domain
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
