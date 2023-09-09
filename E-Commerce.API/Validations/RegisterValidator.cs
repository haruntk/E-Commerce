using E_Commerce.API.Models.DTO;
using FluentValidation;

namespace E_Commerce.API.Validations
{
    public class RegisterValidator : AbstractValidator<RegisterRequestDto>
    {
        public RegisterValidator()
        {
            RuleFor(x=>x.Username).NotEmpty().WithMessage("Email Can Not Be Empty").EmailAddress().WithMessage("Enter a Valid Email Address");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password Can Not Be Empty");
        }
    }
}
