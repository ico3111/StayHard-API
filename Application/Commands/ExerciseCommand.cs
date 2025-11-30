namespace StayHard.Application.Commands;

public record ExerciseCommand (string Name, int Sets, int Reps, int WorkoutId);