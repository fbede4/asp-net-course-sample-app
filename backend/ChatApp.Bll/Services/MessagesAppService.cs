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

        public MessagesAppService(
            IMessageRepository messageRepository,
            IUnitOfWork unitOfWork)
        {
            this.messageRepository = messageRepository;
            this.unitOfWork = unitOfWork;
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
        }
    }
}
