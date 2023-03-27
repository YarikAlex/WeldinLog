using FluentValidation;
using MyWeldingLog.Models.Requests.Objects;

namespace MyWeldingLog.Validators.Objects
{
    public class DeleteObjectRequestValidator : AbstractValidator<DeleteObjectRequest>
    {
        public DeleteObjectRequestValidator()
        {
            RuleFor(x => x.ObjectId)
                .GreaterThan(0)
                .WithMessage("ObjectId should be greater than 0.");
        }
    }
}
