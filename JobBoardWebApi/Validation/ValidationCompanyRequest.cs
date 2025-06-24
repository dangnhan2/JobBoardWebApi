using FluentValidation;
using JobBoardWebApi.Dtos.Request;

namespace JobBoardWebApi.Validation
{
    public class ValidationCompanyRequest : AbstractValidator<CompanyRequest>
    {
        public ValidationCompanyRequest() {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required");
            RuleFor(x => x.LogoUrl)
                .NotEmpty()
                .WithMessage("Logo is required");
        }
    }
}
