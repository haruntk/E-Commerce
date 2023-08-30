using E_Commerce.API.Models.DTO;
using FluentValidation;
namespace E_Commerce.API.Validations
{
    public class ProductCategoryValidator : AbstractValidator<AddProductRequestDto>
    {
        public ProductCategoryValidator()
        {
            RuleFor(x => x.ProductCategories).NotEmpty();
        }
    }
}
