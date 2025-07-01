using Application.Common.Results;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Therapists.Commands.RemoveSpecialization
{
    public class RemoveSpecializationHandler : IRequestHandler<RemoveSpecializationCommand, NonGenericResult>
    {
        private readonly IAppDbContext appDbContext;

        public RemoveSpecializationHandler(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<NonGenericResult> Handle(RemoveSpecializationCommand request, CancellationToken cancellationToken)
        {
            var specialization = await appDbContext.TherapistSpecialization
                .FirstOrDefaultAsync(ts => ts.TherapistId == request.TherapistId && ts.Name == request.Name, cancellationToken);

            if (specialization is null)
                return NonGenericResult.Fail("Specialization not found for this therapist.");

            appDbContext.TherapistSpecialization.Remove(specialization);

            var result = await appDbContext.SaveChangesAsync(cancellationToken);

            return result == 1
                ? NonGenericResult.Ok("Specialization removed successfully.")
                : NonGenericResult.Fail("Failed to remove specialization.");
        }
    }
}
