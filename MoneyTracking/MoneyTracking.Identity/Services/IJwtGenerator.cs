using MoneyTracking.Data.Entities;

namespace MoneyTracking.Identity.Services
{
    public interface IJwtGenerator
    {
        string GenerateToken(AppUser user);
    }
}