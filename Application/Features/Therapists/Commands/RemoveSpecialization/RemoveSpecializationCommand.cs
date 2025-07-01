using Application.Common.Results;
using MediatR;

namespace Application.Features.Therapists.Commands.RemoveSpecialization
{
    public record RemoveSpecializationCommand(int TherapistId, string Name)
    : IRequest<NonGenericResult>;
}
