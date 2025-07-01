using Application.Features.Therapists.Commands.AddSpecialization;
using Domain.Entities;

namespace Application.Features.Therapists.Mappings
{
    public class SpecializationProfile : AutoMapper.Profile
    {
        public SpecializationProfile()
        {
            CreateMap<AddSpecializationCommand, TherapistSpecialization>();
        }
    }
}
