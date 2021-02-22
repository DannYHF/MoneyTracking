using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MoneyTracking.API.Models.Entities;
using MoneyTracking.Identity.Models;

namespace MoneyTracking.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;

        public AuthService(UserManager<AppUser> userManager, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
        }
        public async Task<AuthorizationResponse> Login(LoginRequest request)
        {
            var user = await AuthenticateUser(request.Email, request.Password);
            return new AuthorizationResponse()
            {
                Id = user.Id,
                Token = _jwtGenerator.GenerateToken(user)
            };
        }

        public async Task<AuthorizationResponse> Register(RegisterRequest request)
        {
            AppUser user = new()
            {
                FirstName = request.FistName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.Email
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result != IdentityResult.Success)
                return null;
            var authenticateUser = await AuthenticateUser(request.Email, request.Password);
            return new AuthorizationResponse()
            {
                Id = authenticateUser.Id,
                Token = _jwtGenerator.GenerateToken(authenticateUser)
            };
        }
        private async Task<AppUser> AuthenticateUser(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return null;
            var verifyPassword = _userManager.PasswordHasher
                .VerifyHashedPassword(user, user.PasswordHash, password);
            if (verifyPassword != PasswordVerificationResult.Success)
                return null;
            return user;
        }
    }
}