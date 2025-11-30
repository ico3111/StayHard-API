using StayHard.Application.Commands;
using StayHard.Domain.Entities;

namespace StayHard.Application.Interfaces;

public interface IExerciseService
{
    Task<Exercise> CreateExerciseAsync(ExerciseCommand command);
    Task<IEnumerable<Exercise?>> GetExercisesByWorkoutIdAsync(int workoutId);
    Task<Exercise?> GetExerciseByIdAsync(int id);
    Task<IEnumerable<Exercise?>> GetAllAsync();
}

