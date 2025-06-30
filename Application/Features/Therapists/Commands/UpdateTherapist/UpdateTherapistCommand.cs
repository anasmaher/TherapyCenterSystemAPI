using Application.Common.Results;
using Domain.Enums;
using MediatR;

namespace Application.Features.Therapists.Commands.UpdateTherapist
{
    public record UpdateTherapistCommand(
        int Id,
        string FirstName,
        string LastName,
        GenderEnum Gender,
        string Email,
        string PhoneNumber,
        List<string> Specializations,
        int YearsOfExperience,
        bool IsAvailable
    ) : IRequest<NonGenericResult>;
}
