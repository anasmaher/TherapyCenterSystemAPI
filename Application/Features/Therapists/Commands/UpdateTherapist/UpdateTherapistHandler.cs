using Application.Common.Results;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Therapists.Commands.UpdateTherapist;

public class UpdateTherapistHandler : IRequestHandler<UpdateTherapistCommand, NonGenericResult>
{
    private readonly IAppDbContext appDbContext;
    private readonly IMapper mapper;

    public UpdateTherapistHandler(IAppDbContext appDbContext, IMapper mapper)
    {
        this.appDbContext = appDbContext;
        this.mapper = mapper;
    }

    public async Task<NonGenericResult> Handle(UpdateTherapistCommand request, CancellationToken cancellationToken)
    {
        var therapist = await appDbContext.Therapists
            .Include(t => t.Specializations)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (therapist is null)
            return NonGenericResult.Fail("Therapist not found.");

        mapper.Map(request, therapist);

        foreach (var specialization in request.Specializations.Distinct())
        {
            if (therapist.Specializations.Any(s => s.Name == specialization))
                continue;

            therapist.Specializations.Add(new TherapistSpecialization
            {
                TherapistId = therapist.Id,
                Name = specialization
            });
        }

        await appDbContext.SaveChangesAsync(cancellationToken);

        return NonGenericResult.Ok("Therapist updated.");
    }
}
