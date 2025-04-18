using ProductApi.Models;

namespace ProductApi.Services
{
    public interface IUserService
    {
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByUsernameAsync(string username);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> RegisterAsync(string username, string password);
        Task<string?> AuthenticateAsync(string username, string password);
    }
}
