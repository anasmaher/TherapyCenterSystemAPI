using Application.Common.Results;
using Application.Features.Patients.DTOs;
using Application.Features.Therapists.DTOs;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Therapists.Queries.GetAllTherapists
{
    public class GetAllTherapistsHandler : IRequestHandler<GetAllTherapistsQuery, Result<PaginatedResult<TherapistDTO>>>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;

        public GetAllTherapistsHandler(IAppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        private static readonly HashSet<string> AllowedSortFields = new()
        {
            "FirstName", "LastName", "DateOfBirth", "YearsOfExperience"
        };

        public async Task<Result<PaginatedResult<TherapistDTO>>> Handle(GetAllTherapistsQuery request, CancellationToken cancellationToken)
        {
            var query = appDbContext.Therapists.AsNoTracking();

            if (request.Gender is not null)
                query = query.Where(p => p.Gender == request.Gender);

            if (!string.IsNullOrEmpty(request.Specialization))
            {
                query = query.Where(t =>
                    t.Specializations.Any(s =>
                        s.Name.Contains(request.Specialization)));
            }

            if(request.AvailableOnly == true)
                query = query.Where(t => t.IsAvailable == true);
            
            var orderBy = AllowedSortFields.Contains(request.OrderBy) ? request.OrderBy : "FirstName";

            query = request.Ascending
                ? query.OrderBy(p => EF.Property<object>(p, orderBy))
                : query.OrderByDescending(p => EF.Property<object>(p, orderBy));

            var total = await query.CountAsync(cancellationToken);

            var therapists = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ProjectTo<TherapistDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return Result<PaginatedResult<TherapistDTO>>.Ok(new PaginatedResult<TherapistDTO>
            {
                Items = therapists,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = total
            });
        }
    }
}
