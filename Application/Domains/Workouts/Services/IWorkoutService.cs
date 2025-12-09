using StayHard.Application.Domains.Workouts.Models.Commands;
using StayHard.Application.Domains.Workouts.Models.Entities;

namespace StayHard.Application.Domains.Workouts.Services;

public interface IWorkoutService
{
    Task<Workout> CreateWorkoutAsync(WorkoutCommand command);
    Task AttachExerciseAsync(int workoutId, int exerciseId);
    Task<IEnumerable<Workout>> GetUserWorkoutsAsync(int userId);
    Task<Workout?> GetWorkoutByIdAsync(int id);
    Task<IEnumerable<Workout?>> GetAllAsync();
}

