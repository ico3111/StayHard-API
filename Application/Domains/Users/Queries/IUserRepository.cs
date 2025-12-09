namespace StayHard.Application.Domains.Users.Queries;

public interface IUserRepository
{
    Task<int> AddAsync(User user);
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByEmailAsync(string email);
    Task<IEnumerable<User?>> GetAllAsync();
}