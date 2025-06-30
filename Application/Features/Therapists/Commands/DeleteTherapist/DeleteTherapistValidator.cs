using FluentValidation;

namespace Application.Features.Therapists.Commands.DeleteTherapist
{
    public class DeleteTherapistValidator : AbstractValidator<DeleteTherapistCommand>
    {
        public DeleteTherapistValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Therapist ID is required.")
                .GreaterThan(0).WithMessage("Therapist ID must be greater than zero.");
        }
    }
}
