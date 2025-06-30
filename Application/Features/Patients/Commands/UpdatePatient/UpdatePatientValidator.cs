using Application.Features.Patients.Commands.CreatePatient;
using Domain.Enums;
using FluentValidation;

namespace Application.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientValidator : AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Patient ID must be greater than 0.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(100).WithMessage("First name must not exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(100).WithMessage("Last name must not exceed 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(100).WithMessage("Email must not exceed 100 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.")
                .MaximumLength(15).WithMessage("Phone number must not exceed 15 characters.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required.")
                .LessThan(DateTime.Today).WithMessage("Date of birth must be in the past.");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Gender is required.")
                .IsInEnum().WithMessage("Gender must be either Male or Female.");
        }
    }
}
