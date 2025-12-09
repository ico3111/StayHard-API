using Microsoft.AspNetCore.Mvc;
using StayHard.Application.Domains.Workouts.Models.Commands;
using StayHard.Application.Domains.Workouts.Services;

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
    public async Task<IActionResult> CreateWorkout([FromBody] WorkoutCommand command)
    {
        var workout = await _service.CreateWorkoutAsync(command);
        return Ok(workout);
    }

    [HttpPost("attach/{workoutId}/{exerciseId}")]
    public async Task<IActionResult> AttachExercise(int workoutId, int exerciseId)
    {
        await _service.AttachExerciseAsync(workoutId, exerciseId);
        return Ok();
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUser(int userId)
    {
        var workouts = await _service.GetUserWorkoutsAsync(userId);
        return Ok(workouts);
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var workouts = await _service.GetWorkoutByIdAsync(id);
        return Ok(workouts);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var workouts = await _service.GetAllAsync();
        return Ok(workouts);
    }
}
