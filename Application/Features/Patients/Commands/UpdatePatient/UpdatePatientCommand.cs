using Application.Common.Results;
using Domain.Enums;
using MediatR;

namespace Application.Features.Patients.Commands.UpdatePatient
{
    public record UpdatePatientCommand(
        int Id,
        string FirstName,
        string LastName,
        DateTime DateOfBirth,
        string PhoneNumber,
        string Email,
        GenderEnum Gender
    ) : IRequest<Result<int>>;
}
