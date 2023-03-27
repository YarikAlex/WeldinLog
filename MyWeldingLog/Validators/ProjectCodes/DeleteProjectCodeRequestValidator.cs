using FluentValidation;
using MyWeldingLog.Models.Requests.ProjectCodes;

namespace MyWeldingLog.Validators.ProjectCodes
{
    public class DeleteProjectCodeRequestValidator : AbstractValidator<DeleteProjectCodeRequest>
    {
        public DeleteProjectCodeRequestValidator()
        {
            RuleFor(x => x.ProjectCodeId)
                .GreaterThan(0)
                .WithMessage("ProjectCodeId should be greater than 0.");
        }
    }
}