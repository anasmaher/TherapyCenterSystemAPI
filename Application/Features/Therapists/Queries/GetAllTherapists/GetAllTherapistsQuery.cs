using Application.Common.Results;
using Application.Features.Therapists.DTOs;
using Domain.Enums;
using MediatR;

namespace Application.Features.Therapists.Queries.GetAllTherapists
{
    public record GetAllTherapistsQuery(
        int PageNumber = 1,
        int PageSize = 10,
        string? Name = null,
        string? Specialization = null,
        string OrderBy = "FirstName",
        bool Ascending = false,
        GenderEnum? Gender = null,
        bool AvailableOnly = false
    ) : IRequest<Result<PaginatedResult<TherapistDTO>>>;
}
