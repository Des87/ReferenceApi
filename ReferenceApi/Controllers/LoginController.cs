using Microsoft.AspNetCore.Mvc;
using ReferenceApi.Manager;
using Swashbuckle.AspNetCore.Annotations;

namespace ReferenceApi.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginManager loginManager;
        private readonly IUnitOfWork unitOfWork;

        public LoginController(IUnitOfWork unitOfWork, ILoginManager loginManager)
        {
            this.unitOfWork = unitOfWork;
            this.loginManager = loginManager;
        }
      
        [HttpPost("Login")]
        [SwaggerResponse(200, Type = typeof(string))]
        [Produces("application/json")]
        public async Task<IActionResult> Login([FromHeader] string userName, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                {
                    unitOfWork.Dispose();
                    return StatusCode(401, "Invalid username or password");
                }
                var token = loginManager.UserLogin(userName, password);
                unitOfWork.Dispose();
                return StatusCode(200, token.Result);
            }
            catch
            {
                unitOfWork.Dispose();
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
