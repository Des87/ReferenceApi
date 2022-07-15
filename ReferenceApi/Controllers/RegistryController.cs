using Microsoft.AspNetCore.Mvc;
using ReferenceApi.Manager;
using ReferenceApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace ReferenceApi.Controllers
{
    public class RegistryController : Controller
    {
        private readonly IRegistryManager registryManager;
        private readonly IUnitOfWork unitOfWork;

        public RegistryController(IUnitOfWork unitOfWork, IRegistryManager registryManager)
        {
            this.unitOfWork = unitOfWork;
            this.registryManager = registryManager;
        }
      
        [SwaggerResponse(200, Type = typeof(UserInfo))]
        [HttpPost("Registry")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllForecast([FromHeader] string userName, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                {
                    unitOfWork.Dispose();
                    return StatusCode(401, "Invalid username or password");
                }
                registryManager.UserRegistry(userName, password);
                unitOfWork.Dispose();
                return StatusCode(200, "Ok");
            }
            catch
            {
                unitOfWork.Dispose();
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
