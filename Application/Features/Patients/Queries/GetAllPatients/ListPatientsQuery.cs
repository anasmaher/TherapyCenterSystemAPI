using Application.Common.Results;
using Application.Features.Patients.DTOs;
using Domain.Enums;
using MediatR;

namespace Application.Features.Patients.Queries.GetAllPatients
{
    public record ListPatientsQuery(
    int pageNumber = 1,
    int pageSize = 10,
    string? OrderBy = "FirstName",
    bool Ascending = true,
    GenderEnum? Gender = null,
    int? TherapistId = null
) : IRequest<Result<PaginatedResult<PatientDTO>>>;

}
