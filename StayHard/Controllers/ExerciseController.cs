using Microsoft.AspNetCore.Mvc;
using StayHard.Application.DTOs;
using StayHard.Application.Interfaces;

namespace StayHard.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExerciseController(IExerciseService service) : ControllerBase
{
    private readonly IExerciseService _service = service;

    [HttpPost]
    public async Task<IActionResult> CreateExercise([FromBody] ExerciseDto dto)
    {
        var workout = await _service.CreateExerciseAsync(dto);
        return Ok(workout);
    }

    [HttpGet("{workoutId}")]
    public async Task<IActionResult> GetByWorkout(int workoutId)
    {
        var workouts = await _service.GetExercisesByWorkoutIdAsync(workoutId);
        return Ok(workouts);
    }
}
