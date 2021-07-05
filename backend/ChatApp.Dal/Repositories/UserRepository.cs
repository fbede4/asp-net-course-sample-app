﻿using ChatApp.Domain.Model;
using ChatApp.Domain.Repositories;

namespace ChatApp.Dal.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ChatAppDbContext chatDbContext) : base(chatDbContext)
        {
        }
    }
}