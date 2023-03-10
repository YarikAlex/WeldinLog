using FluentValidation;
using MyWeldingLog.Models.Requests.ProjectCodes;

namespace MyWeldingLog.Validators.ProjectCodes
{
    public class CreateNewProjectCodeRequestValidator : AbstractValidator<CreateNewProjectCodeRequest>
    {
        public CreateNewProjectCodeRequestValidator()
        {
            RuleFor(x => x.HierarchyId)
                .GreaterThan(0)
                .WithMessage("HierarchyId should be greater than 0.");

            RuleFor(x => x.ProjectCodeName)
                .NotEmpty()
                .WithMessage("Project code name should not be empty");
        }
    }
}