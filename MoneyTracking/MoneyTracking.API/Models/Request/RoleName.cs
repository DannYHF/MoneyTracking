using System.ComponentModel.DataAnnotations;

namespace MoneyTracking.API.Models.Request
{
    public class RoleQuery
    {
        [Required]
        public string RoleName { get; set; }
    }
}