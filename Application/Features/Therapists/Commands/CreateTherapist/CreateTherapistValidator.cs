using FluentValidation;

namespace Application.Features.Therapists.Commands.CreateTherapist
{
    public class CreateTherapistValidator : AbstractValidator<CreateTherapistCommand>
    {
        public CreateTherapistValidator()
        {
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

            RuleFor(x => x.Specializations)
                .NotNull().WithMessage("Specializations are required.")
                .Must(x => x.Count > 0).WithMessage("At least one specialization must be provided.")
                .Must(x => x.All(s => !string.IsNullOrWhiteSpace(s))).WithMessage("Specializations must not contain empty or whitespace values.")
                .Must(x => x.Count <= 10).WithMessage("You can specify a maximum of 10 specializations.")
                .Must(x => x.All(s => s.Length <= 50)).WithMessage("Each specialization must not exceed 50 characters.");

            RuleFor(x => x.YearsOfExperience)
                .GreaterThanOrEqualTo(0).WithMessage("Years of experience must be a non-negative number.")
                .LessThanOrEqualTo(100).WithMessage("Years of experience must not exceed 100 years.");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Gender is required.")
                .IsInEnum().WithMessage("Gender must be either Male or Female.");

            RuleFor(x => x.IsAvailable)
                .NotNull().WithMessage("Availability status is required.")
                .Must(x => x == true || x == false).WithMessage("IsAvailable must be a boolean value.");
        }
    }
}
