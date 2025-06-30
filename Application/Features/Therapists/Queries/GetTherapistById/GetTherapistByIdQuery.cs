using Domain.Entities;
using MediatR;

namespace Application.Features.Therapists.Queries.GetTherapistById
{
    public record GetTherapistByIdQuery(int Id) : IRequest<Therapist?>;
}
