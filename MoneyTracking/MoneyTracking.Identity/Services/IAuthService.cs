using System.Threading.Tasks;
using MoneyTracking.Identity.Models;

namespace MoneyTracking.Identity.Services
{
    public interface IAuthService
    {
        Task<AuthorizationResponse> Login(LoginRequest request);
        Task<AuthorizationResponse> Register(RegisterRequest request);
    }
}