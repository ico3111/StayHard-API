using StayHard.Application.DTOs;
using StayHard.Domain.Entities;

namespace StayHard.Application.Interfaces;

public interface IWorkoutService
{
    Task<Workout> CreateWorkoutAsync(WorkoutDto dto);
    Task<IEnumerable<Workout>> GetUserWorkoutsAsync(int userId);

    Task<Workout?> GetWorkoutByIdAsync(int id);
}

