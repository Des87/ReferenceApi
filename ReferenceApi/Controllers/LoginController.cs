using Microsoft.AspNetCore.Mvc;
using ReferenceApi.Manager;
using Swashbuckle.AspNetCore.Annotations;

namespace ReferenceApi.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginManager loginManager;
        private readonly UserInfoRepository userInfoRepository;

        public LoginController()
        {
            this.loginManager = new LoginManager();
            this.userInfoRepository = new UserInfoRepository();
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
        [HttpPost("Login")]
        [SwaggerResponse(200, Type = typeof(string))]
        [Produces("application/json")]
        public async Task<IActionResult> Login([FromHeader] string userName, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                {
                    return StatusCode(401, "Invalid username or password");
                }
                var token = loginManager.UserLogin(userName, password);
                return StatusCode(200, token.Result);
            }
            catch
            {
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
