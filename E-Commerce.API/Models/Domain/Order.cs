using System.ComponentModel.DataAnnotations;

namespace E_Commerce.API.Models.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public double TotalPrice { get; set; }
        public Guid OrderItemId { get; set; }
        public OrderItem OrderItem { get; set; }
    }
    public enum Status
    {
        CANCELED,
        PREPARING,
        READY,
        SENT
    }
}
