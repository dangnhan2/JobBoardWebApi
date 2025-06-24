using FluentValidation;
using JobBoardWebApi.Dtos.Request;

namespace JobBoardWebApi.Validation
{
    public class ValidationRecruiterRequest_ : AbstractValidator<RecruiterPutRequest>
    {
        public ValidationRecruiterRequest_() {
            RuleFor(x => x.UserName)
                  .NotEmpty()
                  .WithMessage("User name is required");
            RuleFor(x => x.Email)
                  .NotEmpty()
                  .WithMessage("Email is required");
            RuleFor(x => x.FullName)
                  .NotEmpty()
                  .WithMessage("Full name is required");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("PhoneNumber is required!.")
                .Matches(@"^(03|05|07|08|09)\d{8}$")
                .WithMessage("Invalid phone number format!.");
            RuleFor(x => x.ProfilePicUrl)
                .NotEmpty()
                .WithMessage("Avatar is required");
            RuleFor(x => x.CompanyId)
                .NotEmpty()
                .WithMessage("Company is required");

        }
    }
}
