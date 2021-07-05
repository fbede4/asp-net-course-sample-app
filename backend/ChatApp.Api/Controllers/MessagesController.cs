using ChatApp.Bll.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public Task SendMessage(string message, int sentByUserId, int conversationId)
        {
            return messagesAppService.SendMessageAsync(message, sentByUserId, conversationId);
        }
    }
}
