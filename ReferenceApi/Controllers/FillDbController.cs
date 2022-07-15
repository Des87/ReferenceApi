using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using ReferenceApi.Manager;
using ReferenceApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace ReferenceApi.Controllers
{
    public class FillDbController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFillDbManager fillDbManager;
        public FillDbController(IUnitOfWork unitOfWork, IFillDbManager fillDbManager)
        {
            this.unitOfWork = unitOfWork;
            this.fillDbManager = fillDbManager;
        }
       
        [SwaggerResponse(200, Type = typeof(Weather))]
        [HttpGet("FillDb")]
        [Produces("application/json")]
        public async Task<IActionResult> FillDb([FromHeader] string city = "Budapest")
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
                        return StatusCode(401, "Unauthorized");
                    }
                }
                var weather = await fillDbManager.FillDb(city);
                unitOfWork.Dispose();
                return StatusCode(200, weather);
            }
            catch
            {
                unitOfWork.Dispose();
                return StatusCode(500, "Something went wrong");
            }
        }
       
        [SwaggerResponse(200, Type = typeof(List<Weather>))]
        [HttpGet("FullfillDb")]
        [Produces("application/json")]
        public async Task<IActionResult> FullfillDb([FromHeader] int numberOf = 15)
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
                        return StatusCode(401, "Unauthorized");
                    }
                }
                var weathers = await fillDbManager.FullfillDb(numberOf);
                unitOfWork.Dispose();
                return StatusCode(200, weathers);
            }
            catch
            {
                unitOfWork.Dispose();
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
