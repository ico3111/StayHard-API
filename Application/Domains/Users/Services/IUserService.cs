using StayHard.Application.Domains.Users.Models.Commands;
using StayHard.Application.Domains.Users.Models.Entities;

namespace StayHard.Application.Domains.Users.Services;

public interface IUserService
{
    Task<string> GetToken(UserCommand command);
    Task<User?> GetUserData(string email);
}