using Microsoft.AspNetCore.Mvc;
using StayHard.Application.DTOs;
using StayHard.Application.Interfaces;

namespace StayHard.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkoutController : ControllerBase
{
    private readonly IWorkoutService _service;

    public WorkoutController(IWorkoutService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateWorkout([FromBody] WorkoutDto dto)
    {
        var workout = await _service.CreateWorkoutAsync(dto);
        return Ok(workout);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUser(int userId)
    {
        var workouts = await _service.GetUserWorkoutsAsync(userId);
        return Ok(workouts);
    }

    [HttpGet("id/{studentId}")]
    public async Task<IActionResult> GetById(int studentId)
    {
        var workouts = await _service.GetUserWorkoutsAsync(studentId);
        return Ok(workouts);
    }
}
