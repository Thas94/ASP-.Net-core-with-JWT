using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestAPI.Models;
using TestAPI.Services.Base;
using TestAPI.Services.Interfaces;

namespace TestAPI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<SecurityToken> Authenticate(UserModel userModel)
        {
            if (userModel.FirstName != "Thabiso" && userModel.LastName != "Malematja")
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var claims = new List<Claim>
                {
                    new(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("FirstName", userModel.FirstName),
                    new Claim("LastName",userModel.LastName),
                };

            var sessionTimeout = Convert.ToInt32(_configuration["SessionTimeoutInMinutes"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(sessionTimeout),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            return tokenHandler.CreateToken(tokenDescriptor);
        }
    }
}
