using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoneyTracking.API.Models.Requests;
using MoneyTracking.API.Models.Responses;

namespace MoneyTracking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public RoleController(RoleManager<IdentityRole> roleManager,
            IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }
        
        [HttpPost]
        //[Authorize(Roles = "admin")]
        [Route("create")]
        public async Task<IActionResult> CreateRole(RoleQuery query)
        {
            if (string.IsNullOrEmpty(query.RoleName))
                return BadRequest("String is null or empty.");
            
            var checkRole = await _roleManager.FindByNameAsync(query.RoleName) != null;
            if (checkRole)
                return BadRequest("This role already exists.");
            
            IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(query.RoleName));
            if (result.Succeeded)
                return Ok(query.RoleName);
            else
                return BadRequest(result.Errors.First().Description);
        }
        
        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("update")]
        public async Task<IActionResult> UpdateRole(UpdateRoleQuery query)
        {
            if (string.IsNullOrEmpty(query.OldName) || string.IsNullOrEmpty(query.NewName))
                return BadRequest("String(s) is null or empty.");
            
            var roleFromStorage = await _roleManager.FindByNameAsync(query.OldName);
            if (roleFromStorage == null)
                return BadRequest("Role not found.");
            
            roleFromStorage.Name = query.NewName;
            IdentityResult result = await _roleManager.UpdateAsync(roleFromStorage);
            if (result.Succeeded)
                return Ok(query.NewName);
            else
                return BadRequest(result.Errors.First().Description);
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("delete")]
        public async Task<IActionResult> DeleteRole(RoleQuery query)
        {
            if (string.IsNullOrEmpty(query.RoleName))
                return BadRequest("String is null or empty.");

            var roleForDelete = await _roleManager.FindByNameAsync(query.RoleName);
            if (roleForDelete == null)
                return BadRequest("Role not found");
            
            IdentityResult result = await _roleManager.DeleteAsync(roleForDelete);
            if (result.Succeeded)
                return Ok(query.RoleName);
            else
                return BadRequest(result.Errors.First().Description);
        }
        
        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("roles")]
        public List<Role> GetRoles()
        {
            var identityRoles = _roleManager.Roles.ToList();
            List<Role> response = _mapper.Map<List<IdentityRole>,List<Role>>(identityRoles);
            return response;
        }
    }
}