using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoneyTracking.API.Models.Request;
using MoneyTracking.API.Models.Response;
using MoneyTracking.Data.Entities;

namespace MoneyTracking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserController(RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> userManager,
            IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        #region Post

        [HttpPost]
        [Route("add-role")]
        public async Task<IActionResult> AddRole(AddRoleToUserQuery query)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid request.");
            
            IdentityRole role = await _roleManager.FindByNameAsync(query.RoleName);
            if (role == null)
                return BadRequest("Role not found.");
            
            AppUser user = await _userManager.FindByIdAsync(query.UserId);
            if (user == null)
                return BadRequest("User not found.");
            
            var result = await _userManager.AddToRoleAsync(user, role.Name);
            if(result != IdentityResult.Success)
                return BadRequest("Failed to add role.");
            
            return Ok(query);
        }

        #endregion

        #region Get

        [HttpGet]
        [Authorize]
        [Route("current")]
        public async Task<IActionResult> GetCurrentUser()
        {
            AppUser currentUser = await _userManager.GetUserAsync(User);
            var userInfo = _mapper.Map<IdentityUser, UserInfo>(currentUser);
            return Ok(userInfo);
        }
        
        #endregion
    }
}