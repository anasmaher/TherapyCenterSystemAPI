using Application.Common.Results;
using Application.Features.Therapists.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Therapists.Queries.GetTherapistById
{
    public class GetTherapistByIdHandler : IRequestHandler<GetTherapistByIdQuery, Result<TherapistDTO>>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;

        public GetTherapistByIdHandler(IAppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        public async Task<Result<TherapistDTO>> Handle(GetTherapistByIdQuery request, CancellationToken cancellationToken)
        {
            var therapist = await appDbContext.Therapists
                .AsNoTracking()
                .Include(x => x.Specializations)

                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        }
    }
}
