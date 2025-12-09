using Dapper;
using System.Data;

namespace StayHard.Application.Domains.Users.Queries;

public class UserQueries(IDbConnection db) : IUserQueries
{
    private readonly IDbConnection _db = db;

    public async Task<int> AddAsync(User user)
    {
        var sqlUser = @"INSERT INTO users (name, email, passwordHash) 
                             VALUES (@name, @email, @passwordHash);
                             SELECT LAST_INSERT_ID();";

        return await _db.QueryFirstOrDefaultAsync<int>(sqlUser, user);
    }

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

    public async Task<IEnumerable<User?>> GetAllAsync()
    {
        var sqlUsers = "SELECT * FROM users";

        var users = (await _db.QueryAsync<User>(sqlUsers)).ToList();

        return users;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var sqlUsers = @"DELETE 
                           FROM users
                          WHERE id = @Id";

        await _db.ExecuteAsync(sqlUsers, new { id });
    }

}
