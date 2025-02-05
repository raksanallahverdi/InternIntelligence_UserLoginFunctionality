
using Business.Dtos;
using Business.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IVacancyService
    {
        Task<Response<List<VacancyDto>>> GetAllVacanciesAsync();
    }
}
