using Microsoft.EntityFrameworkCore;
using TestAPI.Entities.Clinical;
using TestAPI.Services.Base;
using TestAPI.Services.Interfaces;

namespace TestAPI.Services
{
    public class UserService : PersonBaseService, IUserService
    {
        public UserService(persondetails_dataContext context, ILogger <UserService> logger) : base(logger, context)
        {
            
        }

        public async Task<List<User>> GetAllUsers()
        {
            var results = await _DataContext.Users.ToListAsync();
            return results;
        }

        public async Task<List<Address>> GetUserAddress()
        {
            var results = await _DataContext.Addresses.ToListAsync();
            return results;
        }
    }
}
