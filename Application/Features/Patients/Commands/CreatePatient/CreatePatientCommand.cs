using Application.Common.Results;
using Domain.Enums;
using MediatR;

namespace Application.Features.Patients.Commands.CreatePatient
{
    public record CreatePatientCommand(
        string FirstName,
        string LastName,
        DateTime DateOfBirth,
        GenderEnum Gender,
        string Email,
        string PhoneNumber
    ) : IRequest<Result<int>>;
}
