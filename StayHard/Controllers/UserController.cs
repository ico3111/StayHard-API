using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StayHard.Application.Domains.Users.Models.Commands;
using StayHard.Application.Domains.Users.Queries;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StayHard.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserQueries repository) : ControllerBase
{
    private readonly IUserQueries _repository = repository;

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] UserCommand command)
    {
        var user = new User();
        var hashedPassword = user.ReturnHashedPassword(command.Password);
        user = new User(command.Name, command.Email, hashedPassword);
        var id = await _repository.AddAsync(user);
        user.Id = id;
        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserCommand command)
    {
        var userDB = await _repository.GetByEmailAsync(command.Email);

        if (userDB == null)
            return Unauthorized("Usuário não existe.");

        string hashedPassword = userDB.ReturnHashedPassword(command.Password);

        if (userDB.PasswordHash != hashedPassword)
            return Unauthorized("Senha incorreta.");

        var token = GenerateToken(userDB);

        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = false,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddHours(2)
        };

        Response.Cookies.Append("stay-hard-auth", token, cookieOptions);

        return Ok();
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

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("stay-hard-auth");
        return Ok();
    }

    [Authorize]
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _repository.GetAllAsync();
        return Ok(users);
    }

    [Authorize]
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _repository.GetByIdAsync(id);
        return Ok(user);
    }

    [Authorize]
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteByIdAsync(int id)
    {
        await _repository.DeleteByIdAsync(id);
        return Ok();
    }

    [Authorize]
    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        var user = await _repository.GetByEmailAsync(email);
        return Ok(user);
    }
}
