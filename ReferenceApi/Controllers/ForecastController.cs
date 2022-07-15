using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using ReferenceApi.DTOs;
using ReferenceApi.Helper;
using ReferenceApi.Manager;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;

namespace ReferenceApi.Controllers
{
    public class ForecastController : Controller
    {
        private readonly IUnitOfWork iUnitOfWork;
        private readonly ForecastManager forecastManager;
        private readonly Tokenhelper tokenhelper;
        public ForecastController(IUnitOfWork iunitOfWork)
        {
            this.iUnitOfWork = iunitOfWork;
            this.forecastManager = new ForecastManager(iUnitOfWork);
            this.tokenhelper = new Tokenhelper();
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
                var tokenstring = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", string.Empty);
                string user = "Unauthorized";
                if (!string.IsNullOrEmpty(tokenstring))
                {
                    user = await tokenhelper.GetUserFromToken(tokenstring);
                    if (user == null)
                    {
                        return StatusCode(401, "Unauthorized");
                    }
                }
                var forecast = forecastManager.GetAllForecast(location, page, pageSize, orderBy, orderDir, user);
                return StatusCode(200, forecast);
            }
            catch
            {
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
