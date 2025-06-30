using Application.Common.Results;
using Domain.Enums;
using MediatR;

namespace Application.Features.Therapists.Commands.CreateTherapist
{
    public record CreateTherapistCommand(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        List<string> Specializations,
        int YearsOfExperience,
        GenderEnum Gender,
        bool IsAvailable
    ) : IRequest<Result<int>>;
}
