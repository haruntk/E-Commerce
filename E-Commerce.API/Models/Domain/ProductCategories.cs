namespace E_Commerce.API.Models.Domain
{
    public class ProductCategories
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
