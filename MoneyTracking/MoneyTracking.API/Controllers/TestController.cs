using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MoneyTracking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// Check authentication.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("isauthenticated")]
        public IActionResult IsAuthenticated()
        {
            return Ok("You are authenticated.");
        }
    }
}