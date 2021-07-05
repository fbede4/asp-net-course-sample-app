using System.Threading.Tasks;

namespace ChatApp.Bll.Interfaces
{
    public interface IMessagesAppService
    {
        Task SendMessageAsync(string message, int sentByUserId, int conversationId);
    }
}
