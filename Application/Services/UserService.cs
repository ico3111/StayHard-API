using StayHard.Application.DTOs;
using StayHard.Application.Interfaces;
using StayHard.Domain.Entities;
using StayHard.Domain.Interfaces;

namespace StayHard.Application.Services;

public class UserService(IUserRepository repository) : IUserService
{
    private readonly IUserRepository _repository = repository;

    public async Task<User> CreateUserAsync(UserDto dto)
    {

        var user = new User(dto.Name, dto.Email, User.ReturnHashedPassword(dto.Password));
        await _repository.AddAsync(user);
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
}
