using StayHard.Application.Domains.Workouts.Models.Entities;

namespace StayHard.Application.Domains.Workouts.Queries;

public interface IWorkoutQueries
{
    Task<int> AddAsync(Workout workout);
    Task AddExerciseAsync(int workoutId, int exerciseId);
    Task<Workout?> GetByIdAsync(int id);
    Task<IEnumerable<Workout>> GetByUserAsync(int UserId);
    Task<IEnumerable<Workout?>> GetAllAsync();
    
}

