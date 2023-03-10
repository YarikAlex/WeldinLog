using FluentValidation;
using MyWeldingLog.Models.Requests.ProjectCodes;

namespace MyWeldingLog.Validators.ProjectCodes
{
    public class CreateNewProjectCodeRequestValidator : AbstractValidator<CreateNewProjectCodeRequest>
    {
        public CreateNewProjectCodeRequestValidator()
        {
            RuleFor(x => x.ObjectId)
                .GreaterThan(0)
                .WithMessage("ObjectId should be greater than 0.");
            
            RuleFor(x => x.SubObjectId)
                .GreaterThan(0)
                .WithMessage("SubObjectId should be greater than 0.");

            RuleFor(x => x.ProjectCodeName)
                .NotEmpty()
                .WithMessage("Project code name should not be empty");
        }
    }
}