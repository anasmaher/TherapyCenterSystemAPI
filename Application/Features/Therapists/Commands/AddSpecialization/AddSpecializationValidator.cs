using Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Therapists.Commands.AddSpecialization
{
    public class AddSpecializationValidator : AbstractValidator<AddSpecializationCommand>
    {
        private readonly IAppDbContext appDbContext;

        public AddSpecializationValidator(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;

            RuleFor(x => x.TherapistId)
                .GreaterThan(0).WithMessage("Therapist ID must be greater than 0");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Specialization name cannot be empty")
                .MaximumLength(50).WithMessage("Specialization name cannot exceed 50 characters");
        }
    }
}
