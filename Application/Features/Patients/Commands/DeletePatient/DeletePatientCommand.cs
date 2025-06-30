using Application.Common.Results;
using MediatR;

namespace Application.Features.Patients.Commands.DeletePatient
{
    public record DeletePatientCommand(int Id) : IRequest<NonGenericResult>;
}
