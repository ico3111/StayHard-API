using StayHard.Application.Domains.Exercises.Models.Entities;

namespace StayHard.Application.Domains.Exercises.Queries;

public interface IExerciseQueries
{
    Task<Exercise?> GetByIdAsync(int id);
    Task<int> AddAsync(Exercise exercise);
    Task<IEnumerable<Exercise>> GetAllAsync();    
    Task<IEnumerable<Exercise>> GetByUserIdAsync(int userId);
    Task DeleteByIdAsync(int id);
}

