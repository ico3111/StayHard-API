using Dapper;
using StayHard.Domain.Entities;
using StayHard.Domain.Interfaces;
using System.Data;

namespace StayHard.Infrastructure.Repositories;

public class WorkoutRepository(IDbConnection db) : IWorkoutRepository
{
    private readonly IDbConnection _db = db;

    public async Task<Workout?> GetByIdAsync(int id)
    {
        var sqlWorkout = "SELECT * FROM Workouts WHERE id = @Id;";
        var sqlExercises = "SELECT * FROM Exercises WHERE workoutId = @Id;";

        var workout = await db.QueryFirstOrDefaultAsync<Workout>(sqlWorkout, new { id });
        if (workout == null)
            return null;

        var exercises = (await _db.QueryAsync<Exercise>(sqlExercises, new { id })).ToList();
        workout.Exercises = exercises;

        return workout;
    }

    public async Task<IEnumerable<Workout>> GetByUserAsync(int userId)
    {
        var sqlUsers = "SELECT * FROM workouts WHERE userId = @UserId;";
        var sqlExercises = "SELECT * FROM exercises WHERE workoutId = @WorkoutId;";

        var workouts = (await _db.QueryAsync<Workout>(
            sqlUsers,
            new { userId }
        )).ToList();

        if (workouts == null) return Enumerable.Empty<Workout>();

        foreach (var workout in workouts)
        {
            workout.Exercises = (await _db.QueryAsync<Exercise>(
                sqlExercises,
                new { workoutId = workout.Id }
            )).ToList();
        }

        return workouts;
    }

    public async Task AddAsync(Workout workout)
    {
        var sql = @"INSERT INTO Workouts (name, userId)
                         VALUES (@Name, @UserId);";

        await _db.ExecuteAsync(sql, workout);
    }

}
