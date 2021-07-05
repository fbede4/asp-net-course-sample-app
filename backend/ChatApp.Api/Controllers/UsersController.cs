using ChatApp.Bll.Interfaces;
using ChatApp.Bll.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp.Api.Controllers
{
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersAppService usersAppService;

        public UsersController(IUsersAppService usersAppService)
        {
            this.usersAppService = usersAppService;
        }

        [HttpGet("search")]
        public Task<List<UserDto>> GetUsers([FromQuery] string name)
        {
            return usersAppService.GetUsersAsync(name);
        }

        [HttpPost("login/{name}")]
        public Task<UserDto> Login(string name)
        {
            return usersAppService.LoginAsync(name);
        }

        [HttpGet("{id}")]
        public Task<UserDto> GetUser(int id)
        {
            return usersAppService.GetUserAsync(id);
        }

        [HttpPost]
        public Task<int> CreateUser(string name)
        {
            return usersAppService.CreateUserAsync(name);
        }
    }
}
