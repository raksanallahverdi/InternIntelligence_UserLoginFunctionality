using FluentValidation;
using Business.Dtos.Auth;

namespace Business.Validators.Auth
{
    public class AuthRegisterDtoValidator : AbstractValidator<AuthRegisterDto>
    {
        public AuthRegisterDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email must be entered");
            
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Email is not correctly entered");

            RuleFor(x => x.Password.Length)
                .GreaterThanOrEqualTo(8)
                .WithMessage("Password must be miniumum 8 symbols");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithMessage("Passwords didn't match");
        }
    }
}