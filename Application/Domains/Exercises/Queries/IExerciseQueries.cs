using StayHard.Application.Domains.Exercises.Models.Entities;

namespace StayHard.Application.Domains.Exercises.Queries;

public interface IExerciseQueries
{
    Task<IEnumerable<Exercise>> GetAllAsync();
    Task<Exercise?> GetAsync(int id);
    Task<IEnumerable<Exercise>> GetByUserAsync(int userId);
    Task<int> AddAsync(Exercise exercise);
    Task DeleteAsync(int id);
}

