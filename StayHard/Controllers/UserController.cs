using Microsoft.AspNetCore.Mvc;
using StayHard.Application.Domains.Users.Models.Commands;
using StayHard.Application.Domains.Users.Services;

namespace StayHard.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] UserCommand command)
    {
        var user = await _service.CreateUserAsync(command);
        return Ok(user);
    }

    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        var user = await _service.GetUserByEmailAsync(email);
        return Ok(user);
    } 
    
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _service.GetUserByIdAsync(id);
        return Ok(user);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _service.GetAllAsync();
        return Ok(users);
    }
}
