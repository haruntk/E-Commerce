﻿using E_Commerce.API.Repositories.Entities;

namespace E_Commerce.API.Models.DTO
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Guid MainCategoryId { get; set; }
    }
}
