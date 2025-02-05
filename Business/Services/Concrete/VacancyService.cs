
using AutoMapper;
using Business.Dtos;
using Business.Services.Abstract;
using Business.Wrappers;
using Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class VacancyService : IVacancyService
    {
        private readonly IVacancyRepository _vacancyRepository;
        private readonly IMapper _mapper;

        public VacancyService(IVacancyRepository vacancyRepository,
            IMapper mapper)
        {
          _vacancyRepository = vacancyRepository;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public async Task<Response<List<VacancyDto>>> GetAllVacanciesAsync()
        {            
                return new Response<List<VacancyDto>>
                {
                    Data = _mapper.Map<List<VacancyDto>>(await _vacancyRepository.GetAllAsync())
                };
            
        }
    }
}
