using StayHard.Application.DTOs;
using StayHard.Application.Interfaces;
using StayHard.Domain.Entities;
using StayHard.Domain.Interfaces;

namespace StayHard.Application.Services;

public class WorkoutService(IWorkoutRepository repository) : IWorkoutService
{
    private readonly IWorkoutRepository _repository = repository;

    public async Task<Workout> CreateWorkoutAsync(WorkoutDto dto)
    {
        var workout = new Workout(dto.Name, dto.UserId);
        await _repository.AddAsync(workout);
        return workout;
    }

    public async Task<IEnumerable<Workout>> GetUserWorkoutsAsync(int userId)
    {
        return await _repository.GetByUserAsync(userId);
    }

    public async Task<Workout?> GetWorkoutByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
}
