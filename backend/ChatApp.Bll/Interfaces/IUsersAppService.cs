using System.Threading.Tasks;

namespace ChatApp.Application.Interfaces
{
    public interface IUsersAppService
    {
        Task<int> CreateUserAsync(string name);
    }
}
