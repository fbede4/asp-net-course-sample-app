using System.Threading.Tasks;

namespace ChatApp.Bll.Hubs
{
    public interface IChatHub
    {
        Task NewMessage();
    }
}
