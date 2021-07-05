using ChatApp.Bll.Dtos;
using ChatApp.Bll.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp.Api.Controllers
{
    [Route("conversations")]
    public class ConversationsController : ControllerBase
    {
        private readonly IConversationsAppService conversationsAppService;

        public ConversationsController(
            IConversationsAppService conversationsAppService)
        {
            this.conversationsAppService = conversationsAppService;
        }

        [HttpGet]
        public Task<List<ConversationListDto>> GetConversations([FromQuery]int userId)
        {
            return conversationsAppService.GetConversationsAsync(userId);
        }

        [HttpGet("{conversationId}")]
        public Task<ConversationDto> GetConversation(int conversationId, [FromQuery]int userId)
        {
            return conversationsAppService.GetConversationAsync(conversationId, userId);
        }

        [HttpPost]
        public Task<int> CreateConversation(int firstUserId, int secondUserId)
        {
            return conversationsAppService.CreateConversationAsync(new ConversationCreateDto
            {
                FirstUserId = firstUserId,
                SecondUserId = secondUserId
            });
        }
    }
}
