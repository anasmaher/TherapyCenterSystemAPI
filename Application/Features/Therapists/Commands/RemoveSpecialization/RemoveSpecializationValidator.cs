using FluentValidation;

namespace Application.Features.Therapists.Commands.RemoveSpecialization
{
    public class RemoveSpecializationValidator : AbstractValidator<RemoveSpecializationCommand>
    {
        public RemoveSpecializationValidator()
        {
            RuleFor(x => x.TherapistId)
                .GreaterThan(0).WithMessage("Therapist ID must be greater than 0");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Specialization name cannot be empty")
                .MaximumLength(50).WithMessage("Specialization name cannot exceed 50 characters");
        }
    }
}
