using ChatApp.Api.Configuration;
using ChatApp.Api.Dal;
using ChatApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace ChatApp.Api.Controllers
{
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly ChatAppDbContext chatAppDbContext;
        private readonly UserHandlingConfiguration config;

        public UsersController(
            IOptions<UserHandlingConfiguration> options,
            ChatAppDbContext chatAppDbContext)
        {
            this.chatAppDbContext = chatAppDbContext;
            this.config = options.Value;
        }

        [HttpPost]
        public async Task<int> CreateUser(string name)
        {
            if (!config.UserCreationEnabled)
            {
                throw new InvalidOperationException("User creation is disabled");
            }

            var user = new User
            {
                Name = name
            };

            chatAppDbContext.Users.Add(user);

            await chatAppDbContext.SaveChangesAsync();

            return user.Id;
        }
    }
}
