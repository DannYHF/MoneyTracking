using System.ComponentModel.DataAnnotations;

namespace MoneyTracking.API.Models.Queries
{
    public class CreateTransactionQuery
    {
        [Required]
        public string CategoryId { get; set; }
        
        [Required]
        public double Spent { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}