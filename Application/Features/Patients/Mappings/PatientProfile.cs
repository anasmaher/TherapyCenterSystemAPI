using Application.Features.Patients.Commands.CreatePatient;
using Application.Features.Patients.Commands.UpdatePatient;
using Application.Features.Patients.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Patients.Mappings
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientDTO>();
            CreateMap<CreatePatientCommand, Patient>();
            CreateMap<UpdatePatientCommand, Patient>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
