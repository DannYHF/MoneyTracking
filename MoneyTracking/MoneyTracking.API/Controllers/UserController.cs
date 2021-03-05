using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoneyTracking.API.Helpers.ApiExceptions;
using MoneyTracking.API.Models.Queries;
using MoneyTracking.API.Models.Responses;
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

        

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("add-role")] 
        public async Task AddRole(AddRoleToUserQuery query)
        {
            IdentityRole role = await _roleManager.FindByNameAsync(query.RoleName);
            if (role == null)
                throw new NotFoundException(nameof(query.RoleName));
            
            AppUser user = await _userManager.FindByIdAsync(query.UserId);
            if (user == null)
                throw new NotFoundException("User");
            
            var result = await _userManager.AddToRoleAsync(user, role.Name);
            if(result != IdentityResult.Success)
                throw new IdentityResultException(result);
        }

        

        [HttpGet]
        [Authorize]
        [Route("current")]
        public async Task<UserInfo> GetCurrentUser()
        {
            AppUser currentUser = await _userManager.GetUserAsync(User);
            var userInfo = _mapper.Map<IdentityUser, UserInfo>(currentUser);
            userInfo.Roles =  await _userManager.GetRolesAsync(currentUser);
            return userInfo;
        }
    }
}