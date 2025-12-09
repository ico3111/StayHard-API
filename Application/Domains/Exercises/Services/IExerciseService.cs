using StayHard.Application.Domains.Exercises.Models.Commands;
using StayHard.Application.Domains.Exercises.Models.Entities;

namespace StayHard.Application.Domains.Exercises.Services;

public interface IExerciseService
{
    Task<Exercise> CreateExerciseAsync(ExerciseCommand command);
}

