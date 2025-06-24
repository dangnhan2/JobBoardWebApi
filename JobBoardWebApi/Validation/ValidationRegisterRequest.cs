using FluentValidation;
using JobBoardWebApi.Dtos.Request;

namespace JobBoardWebApi.Validation
{
    public class ValidationRegisterRequest : AbstractValidator<RegisterVM>
    {
        public ValidationRegisterRequest() {
            RuleFor(x => x.Email)
                 .NotEmpty()
                 .WithMessage("Email is required")
                 .EmailAddress()
                 .WithMessage("Email is wrong format");
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("Full name is required");
            RuleFor(x => x.Password)
                .Equal(x => x.ConfirmPassword)
                .WithMessage("Passwords do not match!")
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(6)
                .WithMessage("Password contains atleast 6 characters");
        }
    }
}
