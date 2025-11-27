using StayHard.Application.DTOs;
using StayHard.Domain.Entities;

namespace StayHard.Application.Interfaces;

public interface IUserService
{
    Task<User> CreateUserAsync(UserDto dto);
    Task<User?> GetUserByEmailAsync(string email);
    Task<User?> GetUserByIdAsync(int id);
}

