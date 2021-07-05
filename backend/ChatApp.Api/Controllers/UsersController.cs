using ChatApp.Api.Dal;
using ChatApp.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChatApp.Api.Controllers
{
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly ChatAppDbContext chatAppDbContext;

        public UsersController(ChatAppDbContext chatAppDbContext)
        {
            this.chatAppDbContext = chatAppDbContext;
        }

        [HttpPost]
        public async Task<int> CreateUser(string name)
        {
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
