using ChatApp.Api.Dal;
using ChatApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Api.Services
{
    public interface IMessageService
    {
        Task<int> CreateMessageAsync(string message, int senderUserId, int recipientUserId);
        Task<List<string>> GetRecievedMessagesAsync(int userId);
    }

    public class MessageService : IMessageService
    {
        private readonly ChatAppDbContext chatAppDbContext;

        public MessageService(ChatAppDbContext chatAppDbContext)
        {
            this.chatAppDbContext = chatAppDbContext;
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

            chatAppDbContext.Messages.Add(entity);

            await chatAppDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<List<string>> GetRecievedMessagesAsync(int userId)
        {
            var messages = await chatAppDbContext.Messages
                .Where(m => m.RecipientUserId == userId)
                .ToListAsync();

            return messages
                .Select(m => m.Text)
                .ToList();
        }
    }
}
