using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MoneyTracking.API.Models.Queries
{
    public class UpdateCategoryQuery
    {
        [Required]
        public string CategoryId { get; set; }
        
        [MaxLength(15)]
        public string Name { get; set; }
        
        public IFormFile Icon { get; set; }
    }
}