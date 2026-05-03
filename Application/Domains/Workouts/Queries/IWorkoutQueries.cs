using StayHard.Application.Domains.Workouts.Models.Entities;

namespace StayHard.Application.Domains.Workouts.Queries;

public interface IWorkoutQueries
{
    Task<IEnumerable<Workout?>> GetAllAsync();
    Task<Workout?> GetAsync(int id);
    Task<IEnumerable<Workout>> GetByUserAsync(int UserId);
    Task<int> AddAsync(Workout workout);
    Task DeleteAsync(int id);
    Task AddExerciseAsync(int workoutId, int exerciseId);
}

