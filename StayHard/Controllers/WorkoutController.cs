using Microsoft.AspNetCore.Mvc;
using StayHard.Application.Domains.Workouts.Models.Commands;
using StayHard.Application.Domains.Workouts.Models.Entities;
using StayHard.Application.Domains.Workouts.Queries;

namespace StayHard.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkoutController(IWorkoutQueries repository) : ControllerBase
{
    private readonly IWorkoutQueries _repository = repository;

    [HttpPost("create")]
    public async Task<IActionResult> CreateWorkout([FromBody] WorkoutCommand command)
    {
        var workout = new Workout(command.Name, command.Description, command.Date, command.UserId);
        var id = await _repository.AddAsync(workout);
        workout.Id = id;
        return Ok(workout);
    }

    [HttpGet("attach/{workoutId}/{exerciseId}")]
    public async Task<IActionResult> AttachExercise(int workoutId, int exerciseId)
    {
        await _repository.AddExerciseAsync(workoutId, exerciseId);
        return Ok();
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUser(int userId)
    {
        var workouts = await _repository.GetByUserAsync(userId);
        return Ok(workouts);
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var workouts = await _repository.GetByIdAsync(id);
        return Ok(workouts);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var workouts = await _repository.GetAllAsync();
        return Ok(workouts);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeletebyId(int id)
    {
        await _repository.DeleteByIdAsync(id);
        return Ok();
    }
}
