using ChatApp.Bll.Hubs;
using ChatApp.Bll.Interfaces;
using ChatApp.Domain.Model;
using ChatApp.Domain.Repositories;
using ChatApp.Domain.UoW;
using System;
using System.Threading.Tasks;

namespace ChatApp.Bll.Services
{
    public class MessagesAppService : IMessagesAppService
    {
        private readonly IMessageRepository messageRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IChatHub chatHub;

        public MessagesAppService(
            IMessageRepository messageRepository,
            IUnitOfWork unitOfWork,
            IChatHub chatHub)
        {
            this.messageRepository = messageRepository;
            this.unitOfWork = unitOfWork;
            this.chatHub = chatHub;
        }

        public async Task SendMessageAsync(string message, int sentByUserId, int conversationId)
        {
            var entity = new Message
            {
                Text = message,
                CreateDate = DateTime.Now,
                SentByUserId = sentByUserId,
                ConversationId = conversationId
            };
            messageRepository.Insert(entity);
            await unitOfWork.SaveChangesAsync();
            
            await chatHub.NewMessage();
        }
    }
}
