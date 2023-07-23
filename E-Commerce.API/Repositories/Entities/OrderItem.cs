﻿namespace E_Commerce.API.Repositories.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
