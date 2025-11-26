namespace StayHard.Application.DTOs;

public class ExerciseDto
{
    public string Name { get; set; } = string.Empty;
    public int Sets { get; set; }
    public int Reps { get; set; }
    public int WorkoutId { get; set; }
}