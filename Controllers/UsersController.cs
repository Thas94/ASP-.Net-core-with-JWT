using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Entities.Clinical;
using TestAPI.Services.Interfaces;

namespace TestAPI.Controllers
{
    //[Authorize]
    [Route("[controller]/[Action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<User>> GetAllUsers() => await _userService.GetAllUsers();
    }
}
