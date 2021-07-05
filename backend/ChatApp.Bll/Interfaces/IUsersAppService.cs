using ChatApp.Bll.Dtos;
using System.Threading.Tasks;

namespace ChatApp.Application.Interfaces
{
    public interface IUsersAppService
    {
        Task<int> CreateUserAsync(string name);
        Task<UserDto> GetUserAsync(int id);
    }
}
