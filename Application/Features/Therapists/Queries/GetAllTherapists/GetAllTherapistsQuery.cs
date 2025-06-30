using Application.Common.Results;
using Application.Features.Therapists.DTOs;
using MediatR;

namespace Application.Features.Therapists.Queries.GetAllTherapists
{
    public record GetAllTherapistsQuery(
        int PageNumber = 1,
        int PageSize = 10,
        string? Name = null,
        string? Specialization = null,
        string OrderBy = "FirstName",
        bool Ascending = false
    ) : IRequest<Result<List<TherapistDTO>>>;
}
