using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyTracking.Identity.Models;
using MoneyTracking.Identity.Services;

namespace MoneyTracking.Identity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        /// <summary>
        /// For user register.
        /// </summary>
        /// <returns>If registration was successful returns a user id and a JWT Token.
        /// Else returns a error with  a message.
        /// </returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Incorrect request.");
            var response = await _authService.Register(request);
            if(response == null)
                return BadRequest("Incorrect data.");
            return Ok(response);
        }
        /// <summary>
        /// For user login.
        /// </summary>
        /// <returns>If registration was successful returns a user id and a JWT Token.
        /// Else returns a error with  a message.
        /// </returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Incorrect data.");
            var response = await _authService.Login(request);
            if(response == null)
                return BadRequest("Incorrect password or email.");
            return Ok(response);
        }
    }
}