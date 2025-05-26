using FluentValidation;
using JobBoardWebApi.Dtos;

namespace JobBoardWebApi.Validation
{
    public class ValidationRegister : AbstractValidator<Register>
    {
        public ValidationRegister() {

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

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(6)
                .WithMessage("Password contains at least 6 characters!.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage("ConfirmPassword is required")
                .Equal(x => x.Password)
                .WithMessage("Pasword does not match");
        }
    }
}
