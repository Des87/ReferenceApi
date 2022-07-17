using Microsoft.AspNetCore.Mvc;
using ReferenceApi.Exceptions;
using ReferenceApi.Helper;
using ReferenceApi.Managers;
using ReferenceApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace ReferenceApi.Controllers
{
    public class RegistryController : Controller
    {
        private readonly ILogger<RegistryController> logger;
        private readonly IRegistryManager registryManager;

        public RegistryController(IRegistryManager registryManager, ILogger<RegistryController> logger)
        {
            this.registryManager = registryManager;
            this.logger = logger;
        }
        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <response code="201">Ok (Account created successfully)</response>
        /// <response code="401">Unauthorized (Invalid username or password)</response>
        /// <response code="409">Conflict (The user name you have chosen already exists)</response>
        /// <response code="500">Internal Server Error (Something went wrong)</response>
        [HttpPut]
        [Route("Registry/{username}/{password}")]
        [Produces("application/json")]
        public async Task<IActionResult> Registry(string username, string password)
        {
            try
            {
                logger.LogInformation(username);
                registryManager.UserRegistry(username, password);
                return StatusCode(201, "Ok");
            }
            catch (InvalidUserOrPassword ex)
            {
                return StatusCode(401, ex.Message);
            }
            catch (AlreadyExistsException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
