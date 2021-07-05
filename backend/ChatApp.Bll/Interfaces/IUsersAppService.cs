using ChatApp.Bll.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp.Bll.Interfaces
{
    public interface IUsersAppService
    {
        Task<int> CreateUserAsync(string name);
        Task<UserDto> GetUserAsync(int id);
        Task<List<UserDto>> GetUsersAsync(string name);
        Task<UserDto> LoginAsync(string name);
    }
}
