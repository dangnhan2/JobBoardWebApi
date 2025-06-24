using FluentValidation;
using JobBoardWebApi.Dtos.Request;

namespace JobBoardWebApi.Validation
{
    public class ValidationJobRequest : AbstractValidator<JobRequest>
    {
        public ValidationJobRequest()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required")
                .MaximumLength(255)
                .WithMessage("Title can not longer than 255 characters");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required")
                .MaximumLength(1025)
                .WithMessage("Description can not longer than 1025 characters");
            RuleFor(x => x.Location)
                .NotEmpty()
                .WithMessage("Location is required");
            RuleFor(x => x.Salary)
                .NotEmpty()
                .WithMessage("Salary is required");
            RuleFor(x => x.LevelId)
                .NotEmpty()
                .WithMessage("Level is required");
            RuleFor(x => x.SkillId)
                .NotEmpty()
                .WithMessage("Skill is required");
            RuleFor(x => x.CompanyId)
                .NotEmpty()
                .WithMessage("Company is required");
        }
    }
}
