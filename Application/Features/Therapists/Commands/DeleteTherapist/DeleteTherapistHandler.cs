using Application.Common.Results;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Therapists.Commands.DeleteTherapist
{
    public class DeleteTherapistHandler : IRequestHandler<DeleteTherapistCommand, NonGenericResult>
    {
        private readonly IAppDbContext appDbContext;

        public DeleteTherapistHandler(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<NonGenericResult> Handle(DeleteTherapistCommand request, CancellationToken cancellationToken)
        {
            var therapist = await appDbContext.Therapists.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (therapist is null)
                return NonGenericResult.Fail("Therapist not found");

            appDbContext.Therapists.Remove(therapist);

            await appDbContext.SaveChangesAsync(cancellationToken);

            return NonGenericResult.Ok("Therapist Deleted");
        }
    }
}
