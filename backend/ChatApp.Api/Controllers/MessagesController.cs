using ChatApp.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp.Api.Controllers
{
    [Route("messages")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService messageService;

        public MessagesController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        [HttpGet]
        public Task<List<string>> GetRecievedMessagesAsync(int userId)
        {
            return messageService.GetRecievedMessagesAsync(userId);
        }

        [HttpPost]
        public Task<int> CreateMessageAsync(string message, int senderUserId, int recipientUserId)
        {
            return messageService.CreateMessageAsync(message, senderUserId, recipientUserId);
        }
    }
}
