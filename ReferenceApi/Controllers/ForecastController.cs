using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using ReferenceApi.DTOs;
using ReferenceApi.Helper;
using ReferenceApi.Managers;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;

namespace ReferenceApi.Controllers
{
    public class ForecastController : Controller
    {
        private readonly ILogger<ForecastController> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IForecastManager forecastManager;
        public ForecastController(IUnitOfWork unitOfWork, IForecastManager forecastManager, ILogger<ForecastController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.forecastManager = forecastManager;
            this.logger = logger;
        }

        /// <summary>
        /// Get forecasts data from database, you can use filters
        /// </summary>
        /// <param name="location"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderDir"></param>
        /// <response code="401">Unauthorized (Invalid username or password)</response>
        /// <response code="500">Internal Server Error (Something went wrong)</response>
        [SwaggerResponse(200, Type = typeof(ForecastDTO))]
        [HttpGet]
        [Route("GetForecasts")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllForecast(string location = "",int page = 1, int pageSize = 5, OrderBy orderBy = 0, Direction orderDir = 0)
        {
            try
            {
                var tokenstring = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", string.Empty);
                string user = "Unauthorized";
                if (!string.IsNullOrEmpty(tokenstring))
                {
                    user = unitOfWork.tokenhelper.GetUserFromToken(tokenstring);
                    if (user == null) { throw new UnauthorizedAccessException("Unauthorized"); }
                    logger.LogInformation(user);
                }
                var forecast = forecastManager.GetAllForecast(location, page, pageSize, orderBy, orderDir, user);
                return StatusCode(200, forecast);
            }
            catch (UnauthorizedAccessException ex)
            {
                return StatusCode(401, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
