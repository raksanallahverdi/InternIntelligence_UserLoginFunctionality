using Business.Dtos.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.Auth
{
    public class AuthLoginDtoValidator : AbstractValidator<AuthLoginDto>
    {
        public AuthLoginDtoValidator()
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

        }
    }
}