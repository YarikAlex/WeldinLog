using FluentValidation;
using MyWeldingLog.Models.Requests.Objects;

namespace MyWeldingLog.Validators.Objects
{
    public class CreateNewObjectRequestValidator : AbstractValidator<CreateNewObjectRequest>
    {
        public CreateNewObjectRequestValidator()
        {
            RuleFor(x => x.ObjectName)
                .NotEmpty()
                .WithMessage("ObjectName should not be empty");
        }
    }
}
