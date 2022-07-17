using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using ReferenceApi.Managers;
using ReferenceApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace ReferenceApi.Controllers
{
    public class FillDbController : Controller
    {
        private readonly IFillDbManager fillDbManager;
        public FillDbController(IFillDbManager fillDbManager)
        {
            this.fillDbManager = fillDbManager;
        }
        /// <summary>
        /// Post one sample weather data to the database
        /// </summary>
        /// <param name="city"></param>
        /// <response code="500">Internal Server Error (Something went wrong)</response>
        [SwaggerResponse(204, Type = typeof(Weather))]
        [HttpPost]
        [Route("FillDb/")]
        [Produces("application/json")]
        public async Task<IActionResult> FillDb(string city = "Budapest")
        {
            try
            {
                var weather = await fillDbManager.FillDb(city);
                return StatusCode(204, weather);
            }
            catch
            {
                return StatusCode(500, "Something went wrong");
            }
        }
        /// <summary>
        /// Post more sample weather data to the database
        /// </summary>
        /// <param name="numberOf"></param>
        /// <response code="500">Internal Server Error (Something went wrong)</response>
        [SwaggerResponse(204, Type = typeof(List<Weather>))]
        [HttpPost]
        [Route("FullfillDb/")]
        [Produces("application/json")]
        public async Task<IActionResult> FullfillDb([FromHeader] int numberOf = 15)
        {
            try
            {
                var weathers = await fillDbManager.FullfillDb(numberOf);
                return StatusCode(204, weathers);
            }
            catch
            {
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
