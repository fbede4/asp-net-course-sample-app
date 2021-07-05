using ChatApp.Bll.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp.Bll.Interfaces
{
    public interface IConversationsAppService
    {
        Task<List<ConversationListDto>> GetConversationsAsync(int userId);
        Task<ConversationDto> GetConversationAsync(int conversationId, int userId);
        Task<int> CreateConversationAsync(ConversationCreateDto dto);
    }
}
