using Application.Features.Therapists.Commands.CreateTherapist;
using Application.Features.Therapists.Commands.UpdateTherapist;
using Domain.Entities;
using Application.Features.Therapists.DTOs;

namespace Application.Features.Therapists.Mappings
{
    public class TherapistProfile : AutoMapper.Profile
    {
        public TherapistProfile()
        {
            CreateMap<Therapist, TherapistDTO>()
                .ForMember(dest => dest.Specializations, opt =>
                    opt.MapFrom(src => src.Specializations.Select(s => s.Name)));

            CreateMap<CreateTherapistCommand, Therapist>()
                .ForMember(dest => dest.Specializations, opt => opt.Ignore());

            CreateMap<UpdateTherapistCommand, Therapist>()
                .ForMember(dest => dest.Specializations, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
