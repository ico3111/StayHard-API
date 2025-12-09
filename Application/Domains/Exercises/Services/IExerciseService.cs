using StayHard.Application.Domains.Exercises.Models.Commands;
using StayHard.Application.Domains.Exercises.Models.Entities;

namespace StayHard.Application.Domains.Exercises.Services;

public interface IExerciseService
{
    Task<Exercise> CreateExerciseAsync(ExerciseCommand command);
    Task<IEnumerable<Exercise?>> GetExercisesByWorkoutIdAsync(int workoutId);
    Task<Exercise?> GetExerciseByIdAsync(int id);
    Task<IEnumerable<Exercise?>> GetAllAsync();
}

