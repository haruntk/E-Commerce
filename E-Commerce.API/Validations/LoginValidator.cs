using E_Commerce.API.Models.DTO;
using FluentValidation;

namespace E_Commerce.API.Validations
{
    public class LoginValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username Can Not Be Empty").EmailAddress()
                .WithMessage("Username Must Be A Email Address");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password Can Not Be Empty");
        }
    }
}
