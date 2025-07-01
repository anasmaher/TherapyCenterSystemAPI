using Application.Common.Results;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Patients.Commands.CreatePatient
{
    public class CreatePatientHandler : IRequestHandler<CreatePatientCommand, Result<int>>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;

        public CreatePatientHandler(IAppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            if (await appDbContext.Patients.AnyAsync(t => t.Email == request.Email, cancellationToken))
                return Result<int>.Fail("patient with this email already exists.");

            if (await appDbContext.Patients.AnyAsync(t => t.PhoneNumber == request.PhoneNumber, cancellationToken))
                return Result<int>.Fail("Patient with this phone number already exists.");

            var patient = mapper.Map<Patient>(request);

            appDbContext.Patients.Add(patient);
            var result = await appDbContext.SaveChangesAsync(cancellationToken);

            return result == 1
                ? Result<int>.Ok(patient.Id)
                : Result<int>.Fail("Failed to create patient.");
        }
    }
}
