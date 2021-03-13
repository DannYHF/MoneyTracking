using System;

namespace MoneyTracking.API.Models.Responses
{
    public class TransactionInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        
        public double Spent { get; set; }
        
        public DateTime CreationTime { get; set; }
        
        public string CategoryId { get; set; }
        
    }
}