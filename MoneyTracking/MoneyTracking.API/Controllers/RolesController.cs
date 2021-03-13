using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoneyTracking.API.Helpers.ApiExceptions;
using MoneyTracking.API.Models.Queries;
using MoneyTracking.API.Models;

namespace MoneyTracking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public RolesController(RoleManager<IdentityRole> roleManager,
            IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Creates a new role and returns it.
        /// </summary>
        /// <exception cref="AlreadyExistsException">This role already exists.</exception>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<Role> CreateRole(CreateRoleQuery query)
        {
            var checkRole = await _roleManager.FindByNameAsync(query.RoleName) != null;
            if (checkRole)
                throw new AlreadyExistsException("This role already exists.");
            
            IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(query.RoleName));
            if (!result.Succeeded)
                throw new IdentityResultException(result);

            IdentityRole role = await _roleManager.FindByNameAsync(query.RoleName);
            return new Role
            {
                Id = role.Id,
                Name = role.Name
            };
            
        }
        
        /// <summary>
        /// Updates a role name.
        /// </summary>
        /// <exception cref="NotFoundException">Role with this id not found.</exception>
        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<string> UpdateRole(UpdateRoleQuery query)
        {
            var roleFromStorage = await _roleManager.FindByIdAsync(query.RoleId);
            if (roleFromStorage == null)
                throw new NotFoundException(nameof(query.RoleId));
            
            roleFromStorage.Name = query.NewName;
            IdentityResult result = await _roleManager.UpdateAsync(roleFromStorage);
            if (!result.Succeeded)
                throw new IdentityResultException(result);
            
            return query.NewName;
        }

        /// <summary>
        /// Deletes a role.
        /// </summary>
        /// <exception cref="InvalidRequestException">The id is invalid </exception>
        /// <exception cref="NotFoundException">Role with this id not found.</exception>
        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("{roleId}")]
        public async Task<string> DeleteRole(string roleId)
        {
            if (string.IsNullOrWhiteSpace(roleId))
                throw new InvalidRequestException("roleName is null or empty.");
            
            var roleForDelete = await _roleManager.FindByIdAsync(roleId);
            if (roleForDelete == null)
                throw new NotFoundException(nameof(roleId));
            
            IdentityResult result = await _roleManager.DeleteAsync(roleForDelete);
            if (!result.Succeeded)
                throw new IdentityResultException(result);
            
            return roleId;
        }
        
        /// <summary>
        /// Returns a array with roles.
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "admin")]
        public List<Role> GetRoles()
        {
            var identityRoles = _roleManager.Roles.ToList();
            List<Role> response = _mapper.Map<List<IdentityRole>,List<Role>>(identityRoles);
            return response;
        }
    }
}