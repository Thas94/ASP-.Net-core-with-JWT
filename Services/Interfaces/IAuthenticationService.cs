using Microsoft.IdentityModel.Tokens;
using TestAPI.Models;

namespace TestAPI.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<SecurityToken> Authenticate(UserModel userModel);
    }
}
