using StayHard.Domain.Entities;

namespace StayHard.Domain.Interfaces;

public interface IWorkoutRepository
{
    Task<int> AddAsync(Workout workout);
    Task AddExerciseAsync(int workoutId, int exerciseId);
    Task<Workout?> GetByIdAsync(int id);
    Task<IEnumerable<Workout>> GetByUserAsync(int UserId);
    Task<IEnumerable<Workout?>> GetAllAsync();
    
}

