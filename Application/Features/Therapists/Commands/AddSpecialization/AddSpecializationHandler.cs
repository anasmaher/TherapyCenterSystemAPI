using Application.Common.Results;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Therapists.Commands.AddSpecialization
{
    public class AddSpecializationHandler : IRequestHandler<AddSpecializationCommand, NonGenericResult>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;

        public AddSpecializationHandler(IAppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        public async Task<NonGenericResult> Handle(AddSpecializationCommand request, CancellationToken cancellationToken)
        {
            var existingSpecialization = await appDbContext.TherapistSpecialization
                .FirstOrDefaultAsync(ts => ts.TherapistId == request.TherapistId && ts.Name == request.Name, cancellationToken);

            if (existingSpecialization is not null)
                return NonGenericResult.Fail("Specialization already exists for this therapist.");

            var newSpecialization = mapper.Map<TherapistSpecialization>(request);

            await appDbContext.TherapistSpecialization.AddAsync(newSpecialization, cancellationToken);

            var result = await appDbContext.SaveChangesAsync(cancellationToken);

            return result > 0
                ? NonGenericResult.Ok("Specialization added successfully.")
                : NonGenericResult.Fail("Failed to add specialization.");
        }
    }
}
