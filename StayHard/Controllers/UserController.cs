using Microsoft.AspNetCore.Mvc;
using StayHard.Application.DTOs;
using StayHard.Application.Interfaces;

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
    public async Task<IActionResult> CreateUser([FromBody] UserDto dto)
    {
        var user = await _service.CreateUserAsync(dto);
        return Ok(user);
    }

    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        var workouts = await _service.GetUserByEmailAsync(email);
        return Ok(workouts);
    }
    
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var workouts = await _service.GetUserByIdAsync(id);
        return Ok(workouts);
    }
}
