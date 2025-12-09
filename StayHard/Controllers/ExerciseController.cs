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
    public async Task<IActionResult> CreateExercise([FromBody] ExerciseCommand command)
    {
        var exercise = await _service.CreateExerciseAsync(command);
        return Ok(exercise);
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

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserIdAsync(int userId)
    {
        var exercises = await _repository.GetByUserIdAsync(userId);
        return Ok(exercises);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteByIdAsync(int id)
    {
        await _repository.DeleteByIdAsync(id);
        return Ok();
    }
}
