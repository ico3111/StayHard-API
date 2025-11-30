using StayHard.Application.Commands;

namespace StayHard.Application.Interfaces;

public interface IUserService
{
    Task<User> CreateUserAsync(UserCommand dto);
    Task<User?> GetUserByEmailAsync(string email);
    Task<User?> GetUserByIdAsync(int id);
    Task<IEnumerable<User?>> GetAllAsync();
}

