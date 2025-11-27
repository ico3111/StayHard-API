using StayHard.Application.DTOs;
using StayHard.Application.Interfaces;
using StayHard.Domain.Entities;
using StayHard.Domain.Interfaces;

namespace StayHard.Application.Services;

public class ExerciseService(IExerciseRepository repository) : IExerciseService
{
    private readonly IExerciseRepository _repository = repository;

    public async Task<Exercise> CreateExerciseAsync(ExerciseDto dto)
    {
        var exercise = new Exercise(dto.Name, dto.Sets, dto.Reps, dto.WorkoutId);
        var id = await _repository.AddAsync(exercise);
        exercise.Id = id;
        return exercise;
    }

    public async Task<IEnumerable<Exercise?>> GetExercisesByWorkoutIdAsync(int workoutId)
    {
        return await _repository.GetExercisesByWorkoutIdAsync(workoutId);
    }

    public async Task<Exercise?> GetExerciseByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
    public async Task<IEnumerable<Exercise?>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

}
