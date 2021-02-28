using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MoneyTracking.Data.Entities;
using MoneyTracking.Identity.Models;

namespace MoneyTracking.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(UserManager<AppUser> userManager, 
            IJwtGenerator jwtGenerator,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
            _roleManager = roleManager;
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
            
            var authenticatedUser = await AuthenticateUser(request.Email, request.Password);
            var roleSetResult = await  _userManager.AddToRoleAsync(authenticatedUser, "user");
            if (roleSetResult == null)
                return null;
            
            return new AuthorizationResponse
            {
                Id = authenticatedUser.Id,
                Token = _jwtGenerator.GenerateToken(authenticatedUser)
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