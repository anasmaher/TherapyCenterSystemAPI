using Application.Common.Results;
using Application.Features.Therapists.DTOs;
using MediatR;

namespace Application.Features.Therapists.Queries.GetTherapistById
{
    public record GetTherapistByIdQuery(int Id) : IRequest<Result<TherapistDTO>>;
}
