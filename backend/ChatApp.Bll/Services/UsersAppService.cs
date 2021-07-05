using ChatApp.Application.Interfaces;
using ChatApp.Domain.Configuration;
using ChatApp.Domain.Model;
using ChatApp.Domain.Repositories;
using ChatApp.Domain.UoW;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
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
    }
}
