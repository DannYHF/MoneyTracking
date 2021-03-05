using System.ComponentModel.DataAnnotations;

namespace MoneyTracking.API.Models
{
    public class Role
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}