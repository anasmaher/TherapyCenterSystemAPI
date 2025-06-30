using Application.Common.Results;
using Application.Features.Patients.DTOs;
using MediatR;

namespace Application.Features.Patients.Queries.GetAllPatients
{
    public record ListPatientsQuery(
        int pageNumber = 1,
        int pageSize = 10,
        string? OrderBy = "FirstName",
        bool Ascending = true
    ) : IRequest<Result<PaginatedResult<PatientDTO>>>;
}
