using Microsoft.AspNetCore.Mvc;
using StayHard.Application.Domains.Users.Models.Commands;
using StayHard.Application.Domains.Users.Queries;

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

    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        var user = await _repository.GetByEmailAsync(email);
        return Ok(user);
    } 
    
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _repository.GetByIdAsync(id);
        return Ok(user);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _repository.GetAllAsync();
        return Ok(users);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteByIdAsync(int id)
    {
        await _repository.DeleteByIdAsync(id);
        return Ok();
    }
}
