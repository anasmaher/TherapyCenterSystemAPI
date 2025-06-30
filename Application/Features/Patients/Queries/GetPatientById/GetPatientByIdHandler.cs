using Application.Common.Results;
using Application.Features.Patients.DTOs;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Patients.Queries.GetPatientById
{
    public class GetPatientByIdHandler : IRequestHandler<GetPatientByIdQuery, Result<PatientDTO>>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;

        public GetPatientByIdHandler(IAppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        public async Task<Result<PatientDTO>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var dto = await appDbContext.Patients
                .AsNoTracking()
                .Where(p => p.Id == request.Id)
                .ProjectTo<PatientDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (dto is null)
                return Result<PatientDTO>.Fail("Patient not found");

            return Result<PatientDTO>.Ok(dto);
        }
    }
}
