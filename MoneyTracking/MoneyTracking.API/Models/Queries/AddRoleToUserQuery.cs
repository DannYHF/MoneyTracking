using System.ComponentModel.DataAnnotations;

namespace MoneyTracking.API.Models.Queries
{
    public class AddRoleToUserQuery
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}