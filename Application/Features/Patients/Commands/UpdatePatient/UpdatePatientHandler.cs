using Application.Common.Results;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, Result<int>>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;

        public UpdatePatientHandler(IAppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        public async Task<Result<int>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await appDbContext.Patients.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (patient is null)
                return Result<int>.Fail("Patient not found");

            mapper.Map(request, patient);

            var result = await appDbContext.SaveChangesAsync(cancellationToken);

            return result == 1
                ? Result<int>.Ok(patient.Id)
                : Result<int>.Fail("Failed to update patient.");
        }
    }
}
