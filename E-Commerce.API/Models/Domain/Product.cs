using System.ComponentModel.DataAnnotations;

namespace E_Commerce.API.Models.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Guid ProductCategoriesId { get; set; }
        public ProductCategories ProductCategories { get; set; }
    }
}
