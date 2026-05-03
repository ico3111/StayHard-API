using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayHard.Application.Domains.Workouts.Models.Commands;
using StayHard.Application.Domains.Workouts.Models.Entities;
using StayHard.Application.Domains.Workouts.Queries;

namespace StayHard.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class WorkoutController(IWorkoutQueries repository) : ControllerBase
{
    private readonly IWorkoutQueries _repository = repository;

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var workouts = await _repository.GetAllAsync();
        return Ok(workouts);
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var workouts = await _repository.GetAsync(id);
        return Ok(workouts);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUser(int userId)
    {
        var workouts = await _repository.GetByUserAsync(userId);
        return Ok(workouts);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] WorkoutCommand command)
    {
        var workout = new Workout(command.Name, command.Description, command.Date, command.UserId);
        var id = await _repository.AddAsync(workout);
        workout.Id = id;
        return Ok(workout);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("attach/{workoutId}/{exerciseId}")]
    public async Task<IActionResult> AttachExercise(int workoutId, int exerciseId)
    {
        await _repository.AddExerciseAsync(workoutId, exerciseId);
        return Ok();
    }
}
