using StayHard.Application.Commands;
using StayHard.Application.Interfaces;
using StayHard.Domain.Interfaces;

namespace StayHard.Application.Services;

public class UserService(IUserRepository repository) : IUserService
{
    private readonly IUserRepository _repository = repository;

    public async Task<User> CreateUserAsync(UserCommand command)
    {

        var user = new User(command.Name, command.Email, User.ReturnHashedPassword(command.Password));
        var id = await _repository.AddAsync(user);
        user.Id = id;
        return user;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _repository.GetByEmailAsync(email);
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<User?>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}
