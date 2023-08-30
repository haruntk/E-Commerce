namespace E_Commerce.API.Repositories.Entities
{
    public class ProductCategory
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ProductId { get; set; }
        public bool IsMain { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
