using StayHard.Application.Domains.Users.Models.Entities;

namespace StayHard.Application.Domains.Users.Queries;

public interface IUserQueries
{
    Task<IEnumerable<User?>> GetAllAsync();
    Task<User?> GetAsync(int id);
    Task<User?> GetByEmailAsync(string email);
    Task<int> AddAsync(User user);
    Task DeleteAsync(int id);
}