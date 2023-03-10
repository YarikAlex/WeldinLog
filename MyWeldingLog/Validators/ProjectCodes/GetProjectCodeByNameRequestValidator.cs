using System.Data;
using FluentValidation;
using MyWeldingLog.Models.Requests.ProjectCodes;

namespace MyWeldingLog.Validators.ProjectCodes
{
    public class GetProjectCodeByNameRequestValidator : AbstractValidator<GetProjectCodeByNameRequest>
    {
        public GetProjectCodeByNameRequestValidator()
        {
            RuleFor(x => x.ProjectCodeName)
                .NotEmpty()
                .WithMessage("Project code name should not be empty.");
        }
    }
}