using FluentValidation;
using JobBoardWebApi.Dtos.Request;

namespace JobBoardWebApi.Validation
{
    public class ValidationSkillRequest : AbstractValidator<SkillRequest>
    {
        public ValidationSkillRequest() {
            RuleFor(x => x.Name)
                  .NotEmpty()
                  .WithMessage("Skill is required")
                  .MaximumLength(15)
                  .WithMessage("Name can not longer than 15 characters");
        }
    }
}
