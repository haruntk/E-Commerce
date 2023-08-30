
using E_Commerce.API.Repositories.Entities;

namespace E_Commerce.API.Repositories.Interfaces
{
    public interface IProductCategoryRepository
    {
       public Task<int> Create(List<ProductCategory> productCategories);
    }
}
