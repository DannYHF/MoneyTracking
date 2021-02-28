using System;

namespace MoneyTracking.Data.Entities
{
    public class Transaction
    {
        public string Id { get; set; }
        public double Spend { get; set; }
        public DateTime CreationTime { get; set; }
        
        public Category Category { get; set; }
        public string CategoryId { get; set; }
        
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }

        public Transaction()
        {
            CreationTime = DateTime.Now;
        }
    }
}