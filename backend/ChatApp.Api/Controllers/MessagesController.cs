using ChatApp.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public List<string> GetMessages()
        {
            return messageService.GetMessages();
        }
    }
}
