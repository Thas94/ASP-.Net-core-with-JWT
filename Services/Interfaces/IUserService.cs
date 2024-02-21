using TestAPI.Entities.Clinical;

namespace TestAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<List<Address>> GetUserAddress();
    }
}
