namespace E_Commerce.API.Repositories.Entities
{
    public class ProductCategories
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
