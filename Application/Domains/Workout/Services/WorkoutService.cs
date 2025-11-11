using Application.Domains.Workout.Dtos;
using Application.Domains.Workout.Interfaces;

namespace Application.Domains.Workout.Services;

public class WorkoutService : IWorkoutService
{
    public WorkoutDto GetWorkout()
    {
        return new WorkoutDto(10, "Treino de terça", 20);
    }
}
