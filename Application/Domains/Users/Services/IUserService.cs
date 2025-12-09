using StayHard.Application.Domains.Users.Models.Commands;

namespace StayHard.Application.Domains.Users.Services;

public interface IUserService
{
    Task<User> CreateUserAsync(UserCommand dto);
    Task<User?> GetUserByEmailAsync(string email);
    Task<User?> GetUserByIdAsync(int id);
    Task<IEnumerable<User?>> GetAllAsync();
}

