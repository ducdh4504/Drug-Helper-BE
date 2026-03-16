using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class UpdateProfileDtoValidator : AbstractValidator<UpdateProfileDto>
    {
        public UpdateProfileDtoValidator()
        {
            RuleFor(x => x.FullName)
                .MaximumLength(50).WithMessage("Full name cannot exceed 50 characters");

            RuleFor(x => x.Phone)
                .Matches(@"^[0-9]+$").WithMessage("Phone must contain only numbers")
                .MaximumLength(13).WithMessage("Phone cannot exceed 13 characters")
                .When(x => !string.IsNullOrEmpty(x.Phone));

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.Today.AddYears(-13)).WithMessage("Must be at least 13 years old")
                .When(x => x.DateOfBirth.HasValue);
        }
    }

}
