using System.ComponentModel.DataAnnotations;

namespace MoneyTracking.API.Models.Queries
{
    public class UpdateRoleQuery
    {
        [Required]
        public string RoleId { get; set; }
        [Required]
        public string NewName { get; set; }
    }
}