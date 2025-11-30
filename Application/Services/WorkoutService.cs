using StayHard.Application.Commands;
using StayHard.Application.Interfaces;
using StayHard.Domain.Entities;
using StayHard.Domain.Interfaces;

namespace StayHard.Application.Services;

public class WorkoutService(IWorkoutRepository repository) : IWorkoutService
{
    private readonly IWorkoutRepository _repository = repository;

    public async Task<Workout> CreateWorkoutAsync(WorkoutCommand dto)
    {
        var workout = new Workout(dto.Name, dto.UserId);
        var id =await _repository.AddAsync(workout);
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
