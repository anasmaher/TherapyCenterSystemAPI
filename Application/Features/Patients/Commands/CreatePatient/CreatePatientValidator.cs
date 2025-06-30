using Domain.Enums;
using FluentValidation;

namespace Application.Features.Patients.Commands.CreatePatient
{
    public class CreatePatientValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.DateOfBirth).LessThan(DateTime.Today);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Gender).NotEmpty().Must(x => x == GenderEnum.Male || x == GenderEnum.Female);
        }
    }
}
