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

    [HttpPost]
    public async Task<IActionResult> CreateWorkout([FromBody] WorkoutDto dto)
    {
        var workout = await _service.CreateWorkoutAsync(dto);
        return Ok(workout);
    }

    [HttpGet("{studentId}")]
    public async Task<IActionResult> GetByStudent(int studentId)
    {
        var workouts = await _service.GetStudentWorkoutsAsync(studentId);
        return Ok(workouts);
    }
}
