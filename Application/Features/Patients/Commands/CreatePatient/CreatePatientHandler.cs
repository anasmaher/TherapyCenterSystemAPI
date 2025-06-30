using Application.Common.Results;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

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
            
            var patient = mapper.Map<Patient>(request);

            appDbContext.Patients.Add(patient);
            await appDbContext.SaveChangesAsync(cancellationToken);

            return Result<int>.Ok(patient.Id);
        }
    }
}
