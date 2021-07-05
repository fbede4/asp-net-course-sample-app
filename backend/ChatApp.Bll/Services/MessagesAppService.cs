using ChatApp.Application.Interfaces;
using ChatApp.Domain.Model;
using ChatApp.Domain.Repositories;
using ChatApp.Domain.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<string>> GetRecievedMessagesAsync(int userId)
        {
            var messages = await messageRepository.GetMessages(message => message.RecipientUserId == userId);

            return messages
                .Select(message => message.Text)
                .ToList();
        }

        public async Task<int> CreateMessageAsync(string message, int senderUserId, int recipientUserId)
        {
            var entity = new Message
            {
                Text = message,
                CreateDate = DateTime.Now,
                SenderUserId = senderUserId,
                RecipientUserId = recipientUserId
            };

            messageRepository.Insert(entity);

            await unitOfWork.SaveChangesAsync();

            return entity.Id;
        }
    }
}
