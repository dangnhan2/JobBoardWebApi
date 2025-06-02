using FluentValidation;
using JobBoardWebApi.Dtos;

namespace JobBoardWebApi.Validation
{
    public class ValidationSkillAction : AbstractValidator<SkillRequest>
    {
        public ValidationSkillAction() {
            RuleFor(x => x.Name)
                  .NotEmpty()
                  .WithMessage("Skill is required")
                  .MaximumLength(15)
                  .WithMessage("Name can not longer than 15 characters");
        }
    }
}
