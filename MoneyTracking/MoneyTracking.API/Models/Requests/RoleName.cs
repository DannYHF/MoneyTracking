using System.ComponentModel.DataAnnotations;

namespace MoneyTracking.API.Models.Requests
{
    public class RoleQuery
    {
        [Required]
        public string RoleName { get; set; }
    }
}