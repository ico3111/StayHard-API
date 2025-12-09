using StayHard.Application.Domains.Exercises.Models.Entities;

namespace StayHard.Application.Domains.Exercises.Queries;

public interface IExerciseRepository
{
    Task<Exercise?> GetByIdAsync(int id);
    Task<IEnumerable<Exercise>> GetExercisesByWorkoutIdAsync(int workoutId);
    Task<int> AddAsync(Exercise exercise);
    Task<IEnumerable<Exercise>> GetAllAsync();
}

