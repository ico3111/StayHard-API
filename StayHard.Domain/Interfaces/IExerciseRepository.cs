using StayHard.Domain.Entities;

namespace StayHard.Domain.Interfaces;

public interface IExerciseRepository
{
    Task<Exercise?> GetByIdAsync(int id);
    Task<IEnumerable<Exercise>> GetExercisesByWorkoutIdAsync(int workoutId);
    Task AddAsync(Exercise exercise);
}

