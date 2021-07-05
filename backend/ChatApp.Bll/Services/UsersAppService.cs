using ChatApp.Bll.Interfaces;
using ChatApp.Bll.Dtos;
using ChatApp.Domain.Configuration;
using ChatApp.Domain.Model;
using ChatApp.Domain.Repositories;
using ChatApp.Domain.UoW;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Bll.Services
{
    public class UsersAppService : IUsersAppService
    {
        private readonly UserHandlingConfiguration config;
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UsersAppService(
            IOptions<UserHandlingConfiguration> options,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            this.config = options.Value;
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> CreateUserAsync(string name)
        {
            if (!config.UserCreationEnabled)
            {
                throw new ValidationException("User creation is disabled");
            }

            var entity = new User
            {
                Name = name
            };

            userRepository.Insert(entity);

            await unitOfWork.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            var user = await userRepository.GetUserAsync(id);

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name
            };
        }

        public async Task<List<UserDto>> GetUsersAsync(string name)
        {
            var users = await userRepository.GetUsersAsync(name);
            return users
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Name
                }).ToList();
        }

        public async Task<UserDto> LoginAsync(string name)
        {
            var user = await userRepository.GetUserAsync(name);
            if (user == null)
            {
                user = new User
                {
                    Name = name
                };
                userRepository.Insert(user);
                await unitOfWork.SaveChangesAsync();
            }
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name
            };
        }
    }
}
