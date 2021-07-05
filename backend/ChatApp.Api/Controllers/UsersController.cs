using ChatApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<int> CreateUser(string name)
        {
            return await usersAppService.CreateUserAsync(name);
        }
    }
}
