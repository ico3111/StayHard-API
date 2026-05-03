using StayHard.Application.Domains.Users.Models.Entities;
using StayHard.Application.Domains.Users.Models.Commands;
using StayHard.Application.Domains.Users.Queries;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace StayHard.Application.Domains.Users.Services;

public class UserService(IUserQueries repository) : IUserService
{
    private readonly IUserQueries _repository = repository;

    public async Task<string> GetToken(UserCommand command)
    {
        var userDB = await _repository.GetByEmailAsync(command.Email);

        if (userDB == null)
            return "";

        string hashedPassword = userDB.ReturnHashedPassword(command.Password);

        if (userDB.PasswordHash != hashedPassword)
            return "";

        string token = GenerateToken(userDB);

        return token;
    }

    private string GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AiMinhasCoxtaNoMesmoLugar2025cont123456789"));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

    public async Task<User?> GetUserData(string email)
    {
        var user = await _repository.GetByEmailAsync(email);

        return user;
    }
}
