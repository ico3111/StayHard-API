using StayHard.Application.DTOs;
using StayHard.Application.Interfaces;
using StayHard.Domain.Entities;
using StayHard.Domain.Interfaces;

namespace StayHard.Application.Services;

public class WorkoutService : IWorkoutService
{
    private readonly IWorkoutRepository _repository;

    public WorkoutService(IWorkoutRepository repository)
    {
        _repository = repository;
    }

    public async Task<Workout> CreateWorkoutAsync(WorkoutDto dto)
    {
        var workout = new Workout(dto.Name, dto.StudentId);
        await _repository.AddAsync(workout);
        return workout;
    }

    public async Task<IEnumerable<Workout>> GetStudentWorkoutsAsync(int studentId)
    {
        return await _repository.GetByStudentAsync(studentId);
    }
}
