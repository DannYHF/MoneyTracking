using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyTracking.API.Models.Queries;
using MoneyTracking.API.Models.Responses;
using MoneyTracking.Data.Entities;

namespace MoneyTracking.API.Services.Interfaces
{
    public interface ICategoriesService
    {
        
        /// <returns>Category id.</returns>
        Task<string> CreateCategory(CreateCategoryQuery query, string userId);
        Task DeleteCategory(string categoryId);
        Task<CategoryInfo> UpdateCategory(UpdateCategoryQuery query);
        CategoryInfo GetCategoryById(string categoryId);
        List<CategoryInfo> GetCategories(string userId);
    }
}