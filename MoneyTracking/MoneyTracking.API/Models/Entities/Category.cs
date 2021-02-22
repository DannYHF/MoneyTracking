using System.Collections.Generic;
using System.Linq;

namespace MoneyTracking.API.Models.Entities
{
    public class Category
    {
        public string Id { get; set; }
        public string ImageName { get; set; }
        public string Name { get; set; }

        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public List<Transaction> Transactions { get; set; }
        
        public double TotalPrice => Transactions.Sum(t => t.Spend);
    }
}