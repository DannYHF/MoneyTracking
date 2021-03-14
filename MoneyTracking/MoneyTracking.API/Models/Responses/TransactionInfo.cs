using System;

namespace MoneyTracking.API.Models.Responses
{
    public class TransactionInfo
    {
        public string Id { get; set; }
        
        public double Spent { get; set; }
        
        public DateTime CreationTime { get; set; }
        
        public CategoryInfo Category { get; set; }
        
    }
}