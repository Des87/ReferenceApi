using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReferenceApi.Manager;

namespace ReferenceApi.Controllers
{
    public class FullfillDbController : Controller
    {
        // POST: FullfillDbController/Create
        [HttpPost("FullfillDb")]
        public async Task<IActionResult> FullfillDb()
        {
            try
            {
                FullfillDbManager fullfillDbManager = new FullfillDbManager();
                await fullfillDbManager.FullfillDb();
                return StatusCode(200, "Done");
            }
            catch
            {
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
