using StayHard.Application.Domains.Exercises.Models.Commands;
using StayHard.Application.Domains.Exercises.Models.Entities;
using StayHard.Application.Domains.Exercises.Queries;
using StayHard.Application.Domains.Workouts.Queries;

namespace StayHard.Application.Domains.Exercises.Services;

public class ExerciseService(IExerciseQueries ExerciseQueries, IWorkoutQueries WorkoutQueries) : IExerciseService
{
    private readonly IExerciseQueries _ExerciseQueries = ExerciseQueries;
    private readonly IWorkoutQueries _WorkoutQueries = WorkoutQueries;

    public async Task<Exercise> CreateExerciseAsync(ExerciseCommand command)
    {
        var exercise = new Exercise(command.Name, command.Sets, command.Reps, command.UserId);
        var exerciseId = await _ExerciseQueries.AddAsync(exercise);
        if (command.WorkoutId != 0)
        {
            await _WorkoutQueries.AddExerciseAsync(command.WorkoutId, exerciseId);
        }
        exercise.Id = exerciseId;
        return exercise;
    }

}
