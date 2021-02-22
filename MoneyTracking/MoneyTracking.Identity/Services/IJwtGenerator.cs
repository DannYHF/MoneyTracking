using MoneyTracking.API.Models.Entities;

namespace MoneyTracking.Identity.Services
{
    public interface IJwtGenerator
    {
        string GenerateToken(AppUser user);
    }
}