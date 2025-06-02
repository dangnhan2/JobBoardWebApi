using FluentValidation;
using JobBoardWebApi.Dtos;

namespace JobBoardWebApi.Validation
{
    public class ValidationRecruiterAction : AbstractValidator<RecruiterRequest>
    {
        public ValidationRecruiterAction() {
            RuleFor(x => x.Email)
                 .NotEmpty()
                 .WithMessage("Email is required!")
                 .EmailAddress()
                 .WithMessage("Invalid email format!");

            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("FullName is required")
                .MaximumLength(50)
                .WithMessage("FullName can not longer than 50 characters!.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("PhoneNumber is required!.")
                .Matches(@"^(03|05|07|08|09)\d{8}$")
                .WithMessage("Invalid phone number format!.");

            RuleFor(c => c.FullName)
               .NotEmpty()
               .WithMessage("FullName is required")
              .MaximumLength(50)
              .WithMessage("FullName can not longer than 50 characters!.");

            RuleFor(c => c.CompanyId)
                .NotEmpty()
                .WithMessage("Company is required");

        }
    }
}
