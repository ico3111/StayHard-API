using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayHard.Application.Domains.Exercises.Models.Commands;
using StayHard.Application.Domains.Exercises.Queries;
using StayHard.Application.Domains.Exercises.Services;

namespace StayHard.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ExerciseController(IExerciseService service, IExerciseQueries repository) : ControllerBase
{
    private readonly IExerciseService _service = service;
    private readonly IExerciseQueries _repository = repository;

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var exercises = await _repository.GetAllAsync();
        return Ok(exercises);
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var exercises = await _repository.GetAsync(id);
        return Ok(exercises);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUser(int userId)
    {
        var exercises = await _repository.GetByUserAsync(userId);
        return Ok(exercises);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] ExerciseCommand command)
    {
        var exercise = await _service.CreateExerciseAsync(command);
        return Ok(exercise);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return Ok();
    }
}
