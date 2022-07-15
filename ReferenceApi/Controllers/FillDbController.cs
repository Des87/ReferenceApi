using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReferenceApi.Manager;
using ReferenceApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace ReferenceApi.Controllers
{
    public class FillDbController : Controller
    {
        private readonly IUnitOfWork iUnitOfWork;
        private readonly FillDbManager fillDbManager;
        public FillDbController(IUnitOfWork iunitOfWork)
        {
            this.iUnitOfWork = iunitOfWork;
            this.fillDbManager = new FillDbManager(iUnitOfWork);
        }
        /// <summary>
        /// Get course rates 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get api/Rate/d769b3c1-7d0c-ec11-b6e6-002248824dc2
        /// </remarks>
        /// <response code="500">Something went wrong</response>
        [SwaggerResponse(200, Type = typeof(Weather))]
        [HttpGet("FillDb")]
        [Produces("application/json")]
        public async Task<IActionResult> FillDb([FromHeader] string city = "Budapest")
        {
            try
            {
                var weather = await fillDbManager.FillDb(city);
                return StatusCode(200, weather);
            }
            catch
            {
                return StatusCode(500, "Something went wrong");
            }
        }
        /// <summary>
        /// Get course rates 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get api/Rate/d769b3c1-7d0c-ec11-b6e6-002248824dc2
        /// </remarks>
        /// <response code="500">Something went wrong</response>
        [SwaggerResponse(200, Type = typeof(Weather))]
        [HttpGet("FullfillDb")]
        [Produces("application/json")]
        public async Task<IActionResult> FullfillDb([FromHeader] int numberOf = 15)
        {
            try
            {
                FillDbManager fillDbManager = new FillDbManager(iUnitOfWork);
                var weathers = await fillDbManager.FullfillDb(numberOf);
                return StatusCode(200, weathers);
            }
            catch
            {
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
