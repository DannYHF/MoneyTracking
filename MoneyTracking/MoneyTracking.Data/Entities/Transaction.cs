using System;
using System.ComponentModel.DataAnnotations;

namespace MoneyTracking.Data.Entities
{
    public class Transaction
    {
        public string Id { get; set; }
        public double Spent { get; set; }
        public DateTime CreationTime { get; set; }
        
        public Category Category { get; set; }
        public string CategoryId { get; set; }
        
        [Required]
        public AppUser AppUser { get; set; }
        [Required]
        public string AppUserId { get; set; }

        public Transaction()
        {
            CreationTime = DateTime.Now;
        }
    }
}