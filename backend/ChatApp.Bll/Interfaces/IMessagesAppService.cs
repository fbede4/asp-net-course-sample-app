using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp.Application.Interfaces
{
    public interface IMessagesAppService
    {
        Task<List<string>> GetRecievedMessagesAsync(int userId);
        Task<int> CreateMessageAsync(string message, int senderUserId, int recipientUserId);
    }
}
