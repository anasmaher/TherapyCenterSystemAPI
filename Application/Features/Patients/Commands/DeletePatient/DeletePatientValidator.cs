using FluentValidation;

namespace Application.Features.Patients.Commands.DeletePatient
{
    public class DeletePatientValidator : AbstractValidator<DeletePatientCommand>
    {
        public DeletePatientValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Patient ID is required.")
                .GreaterThan(0).WithMessage("Patient ID must be greater than zero.");
        }
    }
}
