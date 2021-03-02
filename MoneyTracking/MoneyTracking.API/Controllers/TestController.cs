using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MoneyTracking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("You are authorized");
        }
    }
}