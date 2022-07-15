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
        private readonly IUnitOfWork unitOfWork;
        private readonly IForecastManager forecastManager;
        public ForecastController(IUnitOfWork unitOfWork, IForecastManager forecastManager)
        {
            this.unitOfWork = unitOfWork;
            this.forecastManager = forecastManager;
        }
      
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
                    user = await unitOfWork.tokenhelper.GetUserFromToken(tokenstring);
                    if (user == null)
                    {
                        unitOfWork.Dispose();
                        return StatusCode(401, "Unauthorized");
                    }
                }
                var forecast = forecastManager.GetAllForecast(location, page, pageSize, orderBy, orderDir, user);
                unitOfWork.Dispose();
                return StatusCode(200, forecast);
            }
            catch
            {
                unitOfWork.Dispose();
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
