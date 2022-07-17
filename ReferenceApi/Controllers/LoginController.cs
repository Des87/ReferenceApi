using Microsoft.AspNetCore.Mvc;
using ReferenceApi.Exceptions;
using ReferenceApi.Managers;
using Swashbuckle.AspNetCore.Annotations;

namespace ReferenceApi.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> logger;
        private readonly ILoginManager loginManager;

        public LoginController(ILoginManager loginManager, ILogger<LoginController> logger)
        {
            this.loginManager = loginManager;
            this.logger = logger;
        }
        /// <summary>
        /// Log in and get token
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <response code="401">Unauthorized (Invalid username or password)</response>
        /// <response code="500">Internal Server Error (Something went wrong)</response>
        [HttpPost]
        [Route("Login/{username}/{password}")]
        [SwaggerResponse(200, Type = typeof(string))]
        [Produces("application/json")]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                logger.LogInformation(username);
                var token = loginManager.UserLogin(username, password);
                return StatusCode(200, token);
            }
            catch (InvalidUserOrPassword ex)
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
