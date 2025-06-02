using FluentValidation;
using JobBoardWebApi.Dtos;

namespace JobBoardWebApi.Validation
{
    public class ValidationCandidateAction : AbstractValidator<CandidateRequest>
    {
        public ValidationCandidateAction() {
            RuleFor(x => x.UserName)
                .MinimumLength(6)
                .MaximumLength(10)
                .WithMessage("User contains at least 6 characters and can not longer than 10 characters");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required!")
                .EmailAddress()
                .WithMessage("Invalid email format!");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("PhoneNumber is required!.")
                .Matches(@"^(03|05|07|08|09)\d{8}$")
                .WithMessage("Invalid phone number format!.");

            RuleFor(x => x.Gender)
               .MinimumLength(10)
               .WithMessage("Gender contains atleast 10 characters!.");

            RuleFor(c => c.FullName)
                .NotEmpty()
                .WithMessage("FullName is required")
               .MaximumLength(50)
               .WithMessage("FullName can not longer than 50 characters!.");


        }
    }
}
