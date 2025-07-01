using Application.Common.Results;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            var patient = await appDbContext.Patients.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (patient is null)
                return NonGenericResult.Fail("Patient not found");

            appDbContext.Patients.Remove(patient);
            var result = await appDbContext.SaveChangesAsync(cancellationToken);

            return result == 1
                ? NonGenericResult.Ok("Patient deleted successfully.")
                : NonGenericResult.Fail("Failed to delete patient.");
        }
    }
}
