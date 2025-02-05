using AutoMapper;
using Business.Dtos;
using Common.Entities;


namespace Business.MappingProfiles
{
    public class VacancyMappingProfile:Profile
    {
        public VacancyMappingProfile()
        {


            CreateMap<Vacancy, VacancyDto>();

        
        }
    }
}
