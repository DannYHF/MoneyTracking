using System.ComponentModel.DataAnnotations;

namespace MoneyTracking.API.Models.Queries
{
    public class CreateRoleQuery
    {
        [Required]
        public string RoleName { get; set; }
    }
}