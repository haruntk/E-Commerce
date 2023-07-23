using System.ComponentModel.DataAnnotations;

namespace E_Commerce.API.Repositories.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Guid MainCategoryId { get; set; }
        public Category MainCategory { get; set; }
    }
}
