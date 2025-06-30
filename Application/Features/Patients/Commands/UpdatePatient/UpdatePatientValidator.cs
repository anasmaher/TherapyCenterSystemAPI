using Application.Features.Patients.Commands.CreatePatient;
using Domain.Enums;
using FluentValidation;

namespace Application.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientValidator : AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID must be greater than zero.");
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100).WithMessage("First name is required and cannot exceed 100 characters.");
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(100).WithMessage("Last name is required and cannot exceed 100 characters.");
            RuleFor(x => x.DateOfBirth).LessThan(DateTime.Today).WithMessage("Date of birth must be in the past.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("A valid email address is required.");
            RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(20).WithMessage("Phone number is required and cannot exceed 20 characters.");
            RuleFor(x => x.Gender).NotEmpty().Must(x => x == GenderEnum.Male || x == GenderEnum.Female).WithMessage("Gender must be either Male or Female.");
        }
    }
}
