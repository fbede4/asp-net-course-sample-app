using ChatApp.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp.Domain.Repositories
{
    public interface IConversationRepository : IRepository<Conversation>
    {
        Task<List<Conversation>> GetConversationsAsync(int userId);
        Task<Conversation> GetConversationAsync(int conversationId);
        Task<bool> GetIfExistsAsync(int firstUserId, int secondUserId);
    }
}
