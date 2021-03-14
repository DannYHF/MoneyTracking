using System.ComponentModel.DataAnnotations;

namespace MoneyTracking.API.Models.Queries
{
    public class UpdateTransactionQuery
    {
        [Required]
        public string TransactionId { get; set; }
        
       [Required]
        public double NewSpent { get; set; }
    }
}