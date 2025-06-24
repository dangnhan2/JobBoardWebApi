using FluentValidation;
using JobBoardWebApi.Dtos.Request;

namespace JobBoardWebApi.Validation
{
    public class ValidationLoginRequest : AbstractValidator<LoginVM>
    {
        public ValidationLoginRequest() {
            RuleFor(x => x.Email)
                 .NotEmpty()
                 .WithMessage("Email is required")
                 .EmailAddress()
                 .WithMessage("Email is wrong format");
            RuleFor(x => x.Password)
                 .NotEmpty()
                 .WithMessage("Password is required");
        }
    }
}
