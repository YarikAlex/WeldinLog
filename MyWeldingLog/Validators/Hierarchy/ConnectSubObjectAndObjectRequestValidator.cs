using FluentValidation;
using MyWeldingLog.Models.Requests.Hierarchy;

namespace MyWeldingLog.Validators.Hierarchy
{
    public class ConnectSubObjectAndObjectRequestValidator : AbstractValidator<ConnectSubObjectAndObjectRequest>
    {
        public ConnectSubObjectAndObjectRequestValidator()
        {
            RuleFor(x => x.ObjectName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Object name should not be empty");
            
            RuleFor(x => x.SubObjectName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Sub-object name should not be empty");
        }
    }
}