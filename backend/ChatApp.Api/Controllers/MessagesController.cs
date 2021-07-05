using ChatApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp.Api.Controllers
{
    [Route("messages")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessagesAppService messagesAppService;

        public MessagesController(IMessagesAppService messagesAppService)
        {
            this.messagesAppService = messagesAppService;
        }

        [HttpGet]
        public Task<List<string>> GetRecievedMessagesAsync(int userId)
        {
            return messagesAppService.GetRecievedMessagesAsync(userId);
        }

        [HttpPost]
        public Task<int> CreateMessageAsync(string message, int senderUserId, int recipientUserId)
        {
            return messagesAppService.CreateMessageAsync(message, senderUserId, recipientUserId);
        }
    }
}
