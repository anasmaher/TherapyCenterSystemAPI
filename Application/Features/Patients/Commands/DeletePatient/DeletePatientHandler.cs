using Application.Common.Results;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Patients.Commands.DeletePatient
{
    public class DeletePatientHandler : IRequestHandler<DeletePatientCommand, NonGenericResult>
    {
        private readonly IAppDbContext appDbContext;

        public DeletePatientHandler(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<NonGenericResult> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await appDbContext.Patients.FindAsync(request.Id);

            if (patient is null)
                return NonGenericResult.Fail("Patient not found");

            appDbContext.Patients.Remove(patient);
            await appDbContext.SaveChangesAsync(cancellationToken);

            return NonGenericResult.Ok();
        }
    }
}
