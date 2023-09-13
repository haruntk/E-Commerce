using E_Commerce.API.Repositories.Entities;

namespace E_Commerce.API.Models.DTO
{
    public class AddProductRequestDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public List<AddProductCategoryDto> ProductCategories { get; set; }
    }
    public class AddProductCategoryDto
    {
        public Guid CategoryId { get; set; }
        public bool IsMain { get; set; }
    }
}
