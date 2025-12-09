using StayHard.Application.Domains.Workouts.Models.Commands;
using StayHard.Application.Domains.Workouts.Models.Entities;
using StayHard.Application.Domains.Workouts.Queries;

namespace StayHard.Application.Domains.Workouts.Services;

public class WorkoutService(IWorkoutRepository repository) : IWorkoutService
{
    private readonly IWorkoutRepository _repository = repository;

    public async Task<Workout> CreateWorkoutAsync(WorkoutCommand command)
    {
        var workout = new Workout(command.Name, command.Description, command.Date, command.UserId);
        var id = await _repository.AddAsync(workout);
        workout.Id = id;
        return workout;
    }
    public async Task AttachExerciseAsync(int workoutId, int exerciseId)
    {
        await _repository.AddExerciseAsync(workoutId, exerciseId);
    }


    public async Task<IEnumerable<Workout>> GetUserWorkoutsAsync(int userId)
    {
        return await _repository.GetByUserAsync(userId);
    }

    public async Task<Workout?> GetWorkoutByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
    public async Task<IEnumerable<Workout?>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

}
