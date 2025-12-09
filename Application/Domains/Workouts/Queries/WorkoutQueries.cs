using Dapper;
using StayHard.Application.Domains.Exercises.Models.Entities;
using StayHard.Application.Domains.Workouts.Models.Entities;
using System.Data;

namespace StayHard.Application.Domains.Workouts.Queries;

public class WorkoutQueries(IDbConnection db) : IWorkoutQueries
{
    private readonly IDbConnection _db = db;

    public async Task<int> AddAsync(Workout workout)
    {
        var sql = @"INSERT INTO Workouts (name, description, date, userId)
                         VALUES (@Name, @Description, @Date, @UserId);
                         SELECT LAST_INSERT_ID();";

        return await _db.QueryFirstOrDefaultAsync<int>(sql, workout);
    }

    public async Task AddExerciseAsync(int workoutId, int exerciseId)
    {
        var sql = @"INSERT INTO workout_exercise (workoutId, exerciseId)
                         VALUES (@WorkoutId, @ExerciseId);";

        await _db.ExecuteAsync(sql, new { workoutId, exerciseId }); 
    
    }

    public async Task<Workout?> GetByIdAsync(int id)
    {
        var sqlWorkout = "SELECT * FROM Workouts WHERE id = @Id;";
        var sqlExercises = @"SELECT exercises.*
                               FROM exercises 
                               JOIN workout_exercise
                                 ON workout_exercise.exerciseId = exercises.id
                              WHERE workout_exercise.workoutId = @WorkoutId;";

        var workout = await db.QueryFirstOrDefaultAsync<Workout>(sqlWorkout, new { id });
        if (workout == null)
            return null;

        var exercises = (await _db.QueryAsync<Exercise>(sqlExercises, new { workoutId = id })).ToList();
        workout.Exercises = exercises;

        return workout;
    }

    public async Task<IEnumerable<Workout>> GetByUserAsync(int userId)
    {
        var sqlWorkouts = "SELECT * FROM workouts WHERE userId = @UserId;";
        var sqlExercises = @"SELECT exercises.*
                               FROM exercises 
                               JOIN workout_exercise
                                 ON workout_exercise.exerciseId = exercises.id
                              WHERE workout_exercise.workoutId = @WorkoutId;";

        var workouts = (await _db.QueryAsync<Workout>(
            sqlWorkouts,
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

    public async Task<IEnumerable<Workout?>> GetAllAsync()
    {
        var sqlWorkouts = "SELECT * FROM workouts";
        var sqlExercises = @"SELECT exercises.*
                               FROM exercises 
                               JOIN workout_exercise
                                 ON workout_exercise.exerciseId = exercises.id
                              WHERE workout_exercise.workoutId = @WorkoutId;";

        var workouts = (await _db.QueryAsync<Workout>(sqlWorkouts)).ToList();

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
    
    public async Task DeleteByIdAsync(int id)
    {
        var sqlWorkout = @"DELETE
                             FROM workouts 
                            WHERE id = @Id";
        await _db.ExecuteAsync(sqlWorkout, new {Id = id});
    }
}
