using StayHard.Domain.Entities;

namespace StayHard.Domain.Interfaces;

public interface IUserRepository
{
    Task<int> AddAsync(User user);
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByEmailAsync(string email);
    Task<IEnumerable<User?>> GetAllAsync();
}

