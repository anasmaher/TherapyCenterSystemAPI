using Application.Common.Results;
using MediatR;

namespace Application.Features.Therapists.Commands.DeleteTherapist
{
    public record DeleteTherapistCommand(int Id) : IRequest<NonGenericResult>;
}
