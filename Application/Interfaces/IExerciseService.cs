using StayHard.Application.DTOs;
using StayHard.Domain.Entities;

namespace StayHard.Application.Interfaces;

public interface IExerciseService
{
    Task<Exercise> CreateExerciseAsync(ExerciseDto dto);
    Task<IEnumerable<Exercise?>> GetExercisesByWorkoutIdAsync(int workoutId);
    Task<Exercise?> GetExerciseByIdAsync(int id);
    Task<IEnumerable<Exercise?>> GetAllAsync();
}

