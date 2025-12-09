namespace StayHard.Application.Domains.Workouts.Models.Commands;

public record WorkoutCommand (string Name, string Description, string Date, int UserId);