using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MoneyTracking.API.Models.Entities;
using MoneyTracking.Options;

namespace MoneyTracking.Identity.Services
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly UserManager<AppUser> _userManager;

        public JwtGenerator(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public string GenerateToken(AppUser user)
        {
            
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthOptions.SecretKey));
            var credentails = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };
            foreach (var userRole in _userManager.GetRolesAsync(user).Result)
                claims.Add(new Claim("role", userRole));
            
            var token = new JwtSecurityToken(AuthOptions.Issuer,
                AuthOptions.Audience,
                claims, 
                expires: DateTime.Now.AddMinutes(AuthOptions.TokenLifetimeInMinutes),
                signingCredentials: credentails);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}