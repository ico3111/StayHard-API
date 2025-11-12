using StayHard.Domain.Entities;

namespace StayHard.Domain.Interfaces;

public interface IWorkoutRepository
{
    Task<Workout?> GetByIdAsync(int id);
    Task<IEnumerable<Workout>> GetByStudentAsync(int studentId);
    Task AddAsync(Workout workout);
}

