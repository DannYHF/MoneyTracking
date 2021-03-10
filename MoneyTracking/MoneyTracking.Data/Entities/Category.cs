using System.Collections.Generic;
namespace MoneyTracking.Data.Entities
{
    public class Category
    {
        public string Id { get; set; }
        public string ImageName { get; set; }
        public string Name { get; set; }
        
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public List<Transaction> Transactions { get; set; }
        
    }
}