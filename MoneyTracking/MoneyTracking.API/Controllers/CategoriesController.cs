using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoneyTracking.API.Helpers.ApiExceptions;
using MoneyTracking.API.Models.Queries;
using MoneyTracking.API.Models.Responses;
using MoneyTracking.API.Services.Interfaces;
using MoneyTracking.Data.Entities;

namespace MoneyTracking.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly UserManager<AppUser> _manager;

        public CategoriesController(ICategoriesService categoriesService, UserManager<AppUser> manager)
        {
            _categoriesService = categoriesService;
            _manager = manager;
        }
        
        /// <summary>
        /// Create a category.
        /// </summary>
        /// <returns>Category id.</returns>
        [HttpPost]
        public async Task<string> CreateCategory([FromForm]CreateCategoryQuery query)
        {
            var userId = _manager.GetUserId(User);
            return await _categoriesService.CreateCategory(query, userId);
        }

        /// <summary>
        /// Delete a category by id.
        /// </summary>
        /// <param name="categoryId">Category id.</param>
        /// <returns>Status code.</returns>
        [HttpDelete]
        [Route("{categoryId}")]
        public async Task<IActionResult> DeleteCategory([Required]string categoryId)
        {
            await  _categoriesService.DeleteCategory(categoryId);
            return StatusCode(200);
        }
        
        /// <summary>
        /// Update a category. Fill in only the ones you need, leave the rest empty.
        /// </summary>
        [HttpPut]
        public async Task<CategoryInfo> UpdateCategory([FromForm]UpdateCategoryQuery query)
        {
            return await  _categoriesService.UpdateCategory(query);
        }
        
        /// <summary>
        /// Returns all categories of the user. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CategoryInfo> GetCategories()
        {
            var userId = _manager.GetUserId(User);
            return  _categoriesService.GetCategories(userId);
        }
        
        /// <summary>
        /// Returns a category by id.
        /// </summary>
        [HttpGet]
        [Route("{categoryId}")]
        public CategoryInfo GetCategoryById(string categoryId)
        {
            if (string.IsNullOrWhiteSpace(categoryId))
                throw new InvalidRequestException("Id can't be null or empty.");
            
            return  _categoriesService.GetCategoryById(categoryId);
        }
    }
}