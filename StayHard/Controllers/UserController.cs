using StayHard.Application.Domains.Users.Models.Entities;
using StayHard.Application.Domains.Users.Models.Commands;
using StayHard.Application.Domains.Users.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StayHard.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserQueries repository) : ControllerBase
{
    private readonly IUserQueries _repository = repository;

    [Authorize]
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _repository.GetAllAsync();
        return Ok(users);
    }

    [Authorize]
    [HttpGet("id/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = await _repository.GetAsync(id);
        return Ok(user);
    }

    [Authorize]
    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        var user = await _repository.GetByEmailAsync(email);
        return Ok(user);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] UserCommand command)
    {
        var user = new User();
        var hashedPassword = user.ReturnHashedPassword(command.Password);
        user = new User(command.Name, command.Email, hashedPassword);
        var id = await _repository.AddAsync(user);
        user.Id = id;
        return Ok(user);
    }

    [Authorize]
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return Ok();
    }
}
