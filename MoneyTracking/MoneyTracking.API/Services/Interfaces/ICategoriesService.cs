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
        Task<Category> UpdateCategory(UpdateCategoryQuery query);
        Task<Category> GetCategoryById(string categoryId);
        List<CategoryInfo> GetCategories(bool doIncludeTransactions, string userId);
    }
}