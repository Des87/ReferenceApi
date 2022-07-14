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
        public FillDbController(IUnitOfWork iunitOfWork)
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
        /// <response code="500">Something went wrong</response>
        [SwaggerResponse(200, Type = typeof(Weather))]
        [HttpGet("FillDb")]
        [Produces("application/json")]
        public async Task<IActionResult> FillDb([FromHeader] string city = "Budapest")
        {
            try
            {
                FillDbManager fillDbManager = new FillDbManager(iUnitOfWork);
                var weather = await fillDbManager.FullfillDb(city);
                return StatusCode(200, weather);
            }
            catch
            {
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
