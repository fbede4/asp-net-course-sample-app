using ChatApp.Bll.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatApp.Api.Hubs
{
    public class ChatHub : Hub<IChatHub>
    {
    }

    public class ChatHubAdapter : IChatHub
    {
        private readonly IHubContext<ChatHub, IChatHub> hubContext;

        public ChatHubAdapter(IHubContext<ChatHub, IChatHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public Task NewMessage()
        {
            return hubContext.Clients.All.NewMessage();
        }
    }
}
