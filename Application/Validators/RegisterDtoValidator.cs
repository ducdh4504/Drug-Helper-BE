using Application.DTOs;
using FluentValidation;
using System;

namespace Application.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required")
                .MinimumLength(4).WithMessage("Username must be at least 4 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email format is invalid");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters");

            RuleFor(x => x.Birthday)
                .NotEmpty().WithMessage("Birthday is required")
                .LessThan(DateTime.Today).WithMessage("Birthday must be in the past")
                .GreaterThan(DateTime.Today.AddYears(-150)).WithMessage("Birthday is not valid");
        }
    }
}
