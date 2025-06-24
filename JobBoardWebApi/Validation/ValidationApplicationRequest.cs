using FluentValidation;
using JobBoardWebApi.Dtos.Request;

namespace JobBoardWebApi.Validation
{
    public class ValidationApplicationRequest : AbstractValidator<ApplicationPostRequest>
    {
        public ValidationApplicationRequest() {
            RuleFor(x => x.CoverLetter)
                 .NotEmpty()
                 .WithMessage("Cover letter is required");
            RuleFor(x => x.File)
                .NotEmpty()
                .WithMessage("Resume is required");
        }
    }
}
