using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReferenceApi.DTOs;
using ReferenceApi.Manager;
using Swashbuckle.AspNetCore.Annotations;

namespace ReferenceApi.Controllers
{
    public class ForecastController : Controller
    {
        private readonly IUnitOfWork iUnitOfWork;
        public ForecastController(IUnitOfWork iunitOfWork)
        {
            this.iUnitOfWork = iunitOfWork;
        }
        /// <summary>
        /// Get course rates 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get api/Rate/d769b3c1-7d0c-ec11-b6e6-002248824dc2
        /// </remarks>
        /// <param name="orderBy"></param>
        /// <param name="orderDir"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <response code="500">Something went wrong</response>
        [SwaggerResponse(200, Type = typeof(ForecastDTO))]
        [HttpGet("GetAllForecast")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllForecast([FromHeader] string location = "",int page = 1, int pageSize = 5, OrderBy orderBy = 0, Direction orderDir = 0)
        {
            try
            {
                ForecastManager forecastManager = new ForecastManager(iUnitOfWork);
                var forecast = forecastManager.GetAllForecast(location, page, pageSize, orderBy, orderDir);
                return StatusCode(200, forecast);
            }
            catch
            {
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
