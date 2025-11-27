using Microsoft.AspNetCore.Mvc;
using StayHard.Application.DTOs;
using StayHard.Application.Interfaces;
using StayHard.Domain.Entities;

namespace StayHard.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExerciseController(IExerciseService service) : ControllerBase
{
    private readonly IExerciseService _service = service;

    [HttpPost("create")]
    public async Task<IActionResult> CreateExercise([FromBody] ExerciseDto dto)
    {
        var exercise = await _service.CreateExerciseAsync(dto);
        return Ok(exercise);
    }

    [HttpGet("workout/{workoutId}")]
    public async Task<IActionResult> GetByWorkout(int workoutId)
    {
        var exercises = await _service.GetExercisesByWorkoutIdAsync(workoutId);
        return Ok(exercises);
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var exercises = await _service.GetExerciseByIdAsync(id);
        return Ok(exercises);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var exercises = await _service.GetAllAsync();
        return Ok(exercises);
    }
}
