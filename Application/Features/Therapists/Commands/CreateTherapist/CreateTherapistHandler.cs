using Application.Common.Results;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Therapists.Commands.CreateTherapist
{
    public class CreateTherapistHandler : IRequestHandler<CreateTherapistCommand, Result<int>>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;

        public CreateTherapistHandler(IAppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateTherapistCommand request, CancellationToken cancellationToken)
        {
            if (await appDbContext.Therapists.AnyAsync(t => t.Email == request.Email, cancellationToken))
                return Result<int>.Fail("Therapist with this email already exists.");

            if (await appDbContext.Therapists.AnyAsync(t => t.PhoneNumber == request.PhoneNumber, cancellationToken))
                return Result<int>.Fail("Therapist with this phone number already exists.");
            var therapist = mapper.Map<Therapist>(request);

            therapist.Specializations = request.Specializations
            .Distinct()
            .Select(name => new TherapistSpecialization
            {
                Therapist = therapist,
                Name = name
            })
            .ToList();

            await appDbContext.Therapists.AddAsync(therapist, cancellationToken);

            var result = await appDbContext.SaveChangesAsync(cancellationToken);

            return result == 1 ?
                Result<int>.Ok(therapist.Id)
                : Result<int>.Fail("Failed to create therapist.");
        }
    }
}
