using Application.Common.Results;
using Application.Features.Patients.DTOs;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Application.Features.Patients.Queries.GetAllPatients;

public class ListPatientsHandler : IRequestHandler<ListPatientsQuery, Result<PaginatedResult<PatientDTO>>>
{
    private readonly IAppDbContext appDbContext;
    private readonly IMapper mapper;

    private static readonly HashSet<string> AllowedSortFields = new()
    {
        "FirstName", "LastName", "Gender"
    };

    public ListPatientsHandler(IAppDbContext appDbContext, IMapper mapper)
    {
        this.appDbContext = appDbContext;
        this.mapper = mapper;
    }

    public async Task<Result<PaginatedResult<PatientDTO>>> Handle(ListPatientsQuery request, CancellationToken cancellationToken)
    {
        var query = appDbContext.Patients.AsNoTracking();

        var orderBy = AllowedSortFields.Contains(request.OrderBy) ? request.OrderBy : "FirstName";

        query = request.Ascending
            ? query.OrderBy(p => EF.Property<object>(p, orderBy))
            : query.OrderByDescending(p => EF.Property<object>(p, orderBy));

        var total = await query.CountAsync(cancellationToken);

        var patients = await query
            .Skip((request.pageNumber - 1) * request.pageSize)
            .Take(request.pageSize)
            .ProjectTo<PatientDTO>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return Result<PaginatedResult<PatientDTO>>.Ok(new PaginatedResult<PatientDTO>
        {
            Items = patients,
            PageNumber = request.pageNumber,
            PageSize = request.pageSize,
            TotalCount = total
        });
    }
}
