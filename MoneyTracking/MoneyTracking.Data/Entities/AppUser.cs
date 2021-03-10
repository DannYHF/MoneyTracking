using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace MoneyTracking.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Category> Categories { get; set; }
        public List<Transaction> Transactions { get; set; }
        
    }
}