using StayHard.Application.Domains.Users.Models.Commands;

namespace StayHard.Application.Domains.Users.Services;

public interface IUserService
{
    Task<string> Login(UserCommand command);
}