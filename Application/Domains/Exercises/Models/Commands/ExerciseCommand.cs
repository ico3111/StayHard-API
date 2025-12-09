namespace StayHard.Application.Domains.Exercises.Models.Commands;

public record ExerciseCommand (string Name, int Sets, int Reps, int UserId, int WorkoutId);