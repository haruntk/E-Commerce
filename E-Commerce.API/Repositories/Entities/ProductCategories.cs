namespace E_Commerce.API.Repositories.Entities
{
    public class ProductCategories
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
