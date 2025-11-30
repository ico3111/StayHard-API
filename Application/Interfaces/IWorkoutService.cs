using StayHard.Application.Commands;
using StayHard.Domain.Entities;

namespace StayHard.Application.Interfaces;

public interface IWorkoutService
{
    Task<Workout> CreateWorkoutAsync(WorkoutCommand dto);
    Task AttachExerciseAsync(int workoutId, int exerciseId);
    Task<IEnumerable<Workout>> GetUserWorkoutsAsync(int userId);
    Task<Workout?> GetWorkoutByIdAsync(int id);
    Task<IEnumerable<Workout?>> GetAllAsync();
}

