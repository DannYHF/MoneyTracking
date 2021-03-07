using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoneyTracking.API.Models.Queries;
using MoneyTracking.API.Models.Responses;
using MoneyTracking.API.Services.Interfaces;
using MoneyTracking.Data.Entities;

namespace MoneyTracking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly UserManager<AppUser> _manager;

        public CategoriesController(ICategoriesService categoriesService, UserManager<AppUser> _manager)
        {
            _categoriesService = categoriesService;
            this._manager = _manager;
        }
        
        [HttpPost]
        [Authorize]
        public async Task<string> CreateCategory([FromForm]CreateCategoryQuery query)
        {
            var userId = _manager.GetUserId(User);
            return await _categoriesService.CreateCategory(query, userId);
        }

        [Authorize]
        [HttpDelete]
        [Route("{categoryId}")]
        public async Task<IActionResult> DeleteCategory([Required]string categoryId)
        {
            await  _categoriesService.DeleteCategory(categoryId);
            return StatusCode(200);
        }
        
        [HttpPut]
        [Authorize]
        public async Task<Category> UpdateCategory(UpdateCategoryQuery query)
        {
            return await  _categoriesService.UpdateCategory(query);
        }

        [HttpGet]
        [Authorize]
        public List<CategoryInfo> GetCategories([Required]bool doIncludeTransactions)
        {
            var userId = _manager.GetUserId(User);
            return  _categoriesService.GetCategories(doIncludeTransactions, userId);
        }
        
        [HttpGet]
        [Authorize]
        [Route("{categoryId}")]
        public async Task<Category> GetCategoryById([Required]string categoryId)
        {
            return await _categoriesService.GetCategoryById(categoryId);
        }
    }
}