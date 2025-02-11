using Business.Dtos;
using Business.Services.Abstract;
using Business.Wrappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize( AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VacancyController:ControllerBase
    {
        private readonly IVacancyService _vacancyService;

        public VacancyController(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }
        #region Documentation
        /// <summary>
        /// Get all vacancies
        /// </summary>
        /// <returns>List of all vacancies</returns>
        #endregion
       
        [ProducesResponseType(typeof(Response<List<VacancyDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<Response<List<VacancyDto>>> GetAllVacanciesAsync()
        {
          

           return await _vacancyService.GetAllVacanciesAsync(); 
        }
    }
}
