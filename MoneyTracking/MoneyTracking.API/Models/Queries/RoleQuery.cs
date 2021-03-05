using System.ComponentModel.DataAnnotations;

namespace MoneyTracking.API.Models.Queries
{
    public class RoleQuery
    {
        [Required]
        public string RoleName { get; set; }
    }
}