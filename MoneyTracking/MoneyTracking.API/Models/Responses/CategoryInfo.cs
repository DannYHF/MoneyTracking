using System.Collections.Generic;
using System.Linq;
using MoneyTracking.Data.Entities;

namespace MoneyTracking.API.Models.Responses
{
    public class CategoryInfo
    {
        public string Id { get; set; }
        
        public string ImageName { get; set; }
        
        public string Name { get; set; }
        
        public List<Transaction> Transactions { get; set; }
        
        public double TotalPrice => Transactions.Sum(t => t.Spend);
    }
}