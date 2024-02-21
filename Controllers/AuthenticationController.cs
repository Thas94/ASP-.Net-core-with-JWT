using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestAPI.Models;
using TestAPI.Services.Interfaces;

namespace TestAPI.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IAuthenticationService authenticationService, IConfiguration configuration)
        {
            _authenticationService = authenticationService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<string> Token([FromBody] UserModel usermodel)
        {
            SecurityToken token = await _authenticationService.Authenticate(usermodel);
            if (token != null)
                return new JwtSecurityTokenHandler().WriteToken(token);
            else
                return "Invalid credentials";

            //var claims = new List<Claim>
            //    {
            //        new(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            //        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //        new(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            //        new Claim("FirstName", usermodel.FirstName),
            //        new Claim("LastName",usermodel.LastName),
            //    };

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            //var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //var token = new JwtSecurityToken(
            //    _configuration["Jwt:Issuer"],
            //    _configuration["Jwt:Audience"],
            //    claims,
            //    expires: DateTime.UtcNow.AddMinutes(10),
            //    signingCredentials: signIn);

            //return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
    }
}
