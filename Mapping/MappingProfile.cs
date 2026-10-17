using AutoMapper;
using HHAManagementSystem.DTOs;
using HHAManagementSystem.Models;

namespace HHAManagementSystem.Services;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Caregiver, CaregiverDto>().ReverseMap();
        CreateMap<Patient, PatientDto>().ReverseMap();
        CreateMap<Visit, VisitDto>().ReverseMap();
    }
}
