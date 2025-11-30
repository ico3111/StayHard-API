using StayHard.Application.Commands;
using StayHard.Application.Interfaces;
using StayHard.Domain.Entities;
using StayHard.Domain.Interfaces;

namespace StayHard.Application.Services;

public class ExerciseService(IExerciseRepository exerciseRepository, IWorkoutRepository workoutRepository) : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository = exerciseRepository;
    private readonly IWorkoutRepository _workoutRepository = workoutRepository;

    public async Task<Exercise> CreateExerciseAsync(ExerciseCommand command)
    {
        var exercise = new Exercise(command.Name, command.Sets, command.Reps);
        var exerciseId = await _exerciseRepository.AddAsync(exercise);
        if (command.WorkoutId != 0)
        {
            await _workoutRepository.AddExerciseAsync(command.WorkoutId, exerciseId);
        }
        exercise.Id = exerciseId;
        return exercise;
    }

    public async Task<IEnumerable<Exercise?>> GetExercisesByWorkoutIdAsync(int workoutId)
    {
        return await _exerciseRepository.GetExercisesByWorkoutIdAsync(workoutId);
    }

    public async Task<Exercise?> GetExerciseByIdAsync(int id)
    {
        return await _exerciseRepository.GetByIdAsync(id);
    }
    public async Task<IEnumerable<Exercise?>> GetAllAsync()
    {
        return await _exerciseRepository.GetAllAsync();
    }

}
