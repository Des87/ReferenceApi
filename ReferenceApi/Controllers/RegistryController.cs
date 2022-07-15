using Microsoft.AspNetCore.Mvc;
using ReferenceApi.Manager;
using ReferenceApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace ReferenceApi.Controllers
{
    public class RegistryController : Controller
    {
        private readonly RegistryManager registryManager;
        public RegistryController()
        {
            this.registryManager = new RegistryManager();
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
        [SwaggerResponse(200, Type = typeof(UserInfo))]
        [HttpPost("Registry")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllForecast([FromHeader] string userName, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                {
                    return StatusCode(401, "Invalid username or password");
                }
                registryManager.UserRegistry(userName, password);
                return StatusCode(200, "Ok");
            }
            catch
            {
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
