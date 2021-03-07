using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using MoneyTracking.API.Helpers;

namespace MoneyTracking.API.Models.Queries
{
    public class UpdateCategoryQuery
    {
        [MaxLength(15)]
        public string Name { get; set; }
        [FileWeight(1024 * 2)]
        public IFormFile Icon { get; set; }
    }
}