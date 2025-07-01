using Application.Common.Results;
using MediatR;

namespace Application.Features.Therapists.Commands.AddSpecialization
{
    public record class AddSpecializationCommand(int TherapistId, string Name) : IRequest<NonGenericResult>;
}
