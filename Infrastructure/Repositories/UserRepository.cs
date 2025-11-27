using Dapper;
using StayHard.Domain.Entities;
using StayHard.Domain.Interfaces;
using System.Data;

namespace StayHard.Infrastructure.Repositories;

public class UserRepository(IDbConnection db) : IUserRepository
{
    private readonly IDbConnection _db = db;

    public async Task<User?> GetByIdAsync(int id)
    {
        var sqlUser = "SELECT * FROM users WHERE id = @Id;";

        var user = await _db.QueryFirstOrDefaultAsync<User>(sqlUser, new { id });

        return user;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var sqlUser = "SELECT * FROM users WHERE email = @Email;";

        var user = await _db.QueryFirstOrDefaultAsync<User>(sqlUser, new { email });
      
        return user;
    }

    public async Task AddAsync(User user)
    {
        var sqlUser = "INSERT INTO users (name, email, passwordHash) VALUES (@name, @email, @passwordHash);";

        await _db.ExecuteAsync(sqlUser, user);
    }

}
