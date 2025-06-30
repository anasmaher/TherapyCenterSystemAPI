using Application.Common.Results;
using Application.Features.Patients.DTOs;
using MediatR;

namespace Application.Features.Patients.Queries.GetPatientById
{
    public record GetPatientByIdQuery(int Id) : IRequest<Result<PatientDTO>>;
}
