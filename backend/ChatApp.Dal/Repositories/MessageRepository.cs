using ChatApp.Domain.Model;
using ChatApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ChatApp.Dal.Repositories
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(ChatAppDbContext chatDbContext) : base(chatDbContext)
        {
        }

        public Task<List<Message>> GetMessagesAsync(Expression<Func<Message, bool>> predicate)
        {
            return chatDbContext.Messages
                .Where(predicate)
                .ToListAsync();
        }
    }
}
