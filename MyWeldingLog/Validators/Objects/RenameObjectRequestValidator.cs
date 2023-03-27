using FluentValidation;
using MyWeldingLog.Models.Requests.Objects;

namespace MyWeldingLog.Validators.Objects
{
    public class RenameObjectRequestValidator : AbstractValidator<RenameObjectRequest>
    {
        public RenameObjectRequestValidator()
        {
            RuleFor(x => x.ObjectId)
                .GreaterThan(0)
                .WithMessage("ObjectId should be greater than 0.");

            RuleFor(x => x.NewObjectName)
                .NotEmpty()
                .WithMessage("New object name should not be empty.");
        }
    }
}
