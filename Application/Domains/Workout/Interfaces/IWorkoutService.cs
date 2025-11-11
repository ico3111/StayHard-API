using Application.Domains.Workout.Dtos;

namespace Application.Domains.Workout.Interfaces;

public interface IWorkoutService
{
    WorkoutDto GetWorkout();
}
