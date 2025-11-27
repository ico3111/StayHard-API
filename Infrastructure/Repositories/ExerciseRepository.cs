using Dapper;
using StayHard.Domain.Entities;
using StayHard.Domain.Interfaces;
using System.Data;

namespace StayHard.Infrastructure.Repositories;

public class ExerciseRepository(IDbConnection db) : IExerciseRepository
{
    private readonly IDbConnection _db = db;

    public async Task<Exercise?> GetByIdAsync(int id)
    {
        var sqlExercises = "SELECT * FROM Exercises WHERE id = @Id;";

        var exercise = await _db.QueryFirstOrDefaultAsync<Exercise>(sqlExercises, new { id });

        return exercise;
    }

    public async Task<IEnumerable<Exercise>> GetExercisesByWorkoutIdAsync(int workoutId)
    {
        var sqlExercises = "SELECT * FROM exercises WHERE workoutId = @WorkoutId;";

        var exercises = (await _db.QueryAsync<Exercise>(
            sqlExercises,
            new { workoutId }
        )).ToList();

        return exercises;
    }

    public async Task<int> AddAsync(Exercise exercise)
    {
        var sqlExercise = @"INSERT INTO exercises (name, sets, reps, workoutId) 
                            VALUES (@Name, @Sets, @Reps, @WorkoutId);
                            SELECT LAST_INSERT_ID();";

        return await _db.QueryFirstOrDefaultAsync<int>(sqlExercise, exercise);
    }

    public async Task<IEnumerable<Exercise>> GetAllAsync()
    {
        var sqlExercise = "SELECT * FROM exercises;";

        var exercises = (await _db.QueryAsync<Exercise>(
            sqlExercise
        )).ToList() ;

        return exercises;
    }

}
