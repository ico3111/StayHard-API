using Microsoft.AspNetCore.Mvc;
using StayHard.Application.Domains.Exercises.Models.Commands;
using StayHard.Application.Domains.Exercises.Queries;
using StayHard.Application.Domains.Exercises.Services;

namespace StayHard.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExerciseController(IExerciseService service, IExerciseQueries repository) : ControllerBase
{
    private readonly IExerciseService _service = service;
    private readonly IExerciseQueries _repository = repository;

    [HttpPost("create")]
    public async Task<IActionResult> CreateExercise([FromBody] ExerciseCommand dto)
    {
        var exercise = await _service.CreateExerciseAsync(dto);
        return Ok(exercise);
    }

    [HttpGet("workout/{workoutId}")]
    public async Task<IActionResult> GetByWorkout(int workoutId)
    {
        var exercises = await _repository.GetByWorkoutIdAsync(workoutId);
        return Ok(exercises);
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var exercises = await _repository.GetByIdAsync(id);
        return Ok(exercises);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var exercises = await _repository.GetAllAsync();
        return Ok(exercises);
    }
}
