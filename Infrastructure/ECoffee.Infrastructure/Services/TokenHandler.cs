using ECoffee.Application.Abstractions.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECoffee.Infrastructure.Services
{
    public class TokenHandler : ITokenHandler
    {
        private IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateAccessToken(string email)
        {
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);
            DateTime expiryDate = DateTime.Now.AddHours(int.Parse(_configuration["JWT:ExpiryInHours"]));

            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Email,email),
            };
            JwtSecurityToken token = new JwtSecurityToken(issuer: _configuration["JWT:Issuer"], audience: _configuration["JWT:Audience"], claims: claims, expires: expiryDate, signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
