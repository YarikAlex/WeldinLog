using FluentValidation;
using MyWeldingLog.Models.Requests.ProjectCodes;

namespace MyWeldingLog.Validators.ProjectCodes
{
    public class RenameProjectCodeRequestValidator : AbstractValidator<RenameProjectCodeRequest>
    {
        public RenameProjectCodeRequestValidator()
        {
            RuleFor(x => x.ProjectCodeId)
                .GreaterThan(0)
                .WithMessage("ProjectCodeId should be greater than 0.");

            RuleFor(x => x.NewProjectCodeName)
                .NotEmpty()
                .WithMessage("New project code name should not be empty.");
        }
    }
}