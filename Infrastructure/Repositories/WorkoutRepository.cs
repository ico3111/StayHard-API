using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using StayHard.Domain.Entities;
using StayHard.Domain.Interfaces;

public class WorkoutRepository(IConfiguration config) : IWorkoutRepository
{
    private readonly string _conn = config.GetConnectionString("DefaultConnection");

    public async Task<Workout?> GetByIdAsync(int id)
    {
        using var db = new MySqlConnection(_conn);

        var sqlWorkout = "SELECT * FROM Workouts WHERE Id = @id;";
        var sqlExercises = "SELECT * FROM Exercises WHERE WorkoutId = @id;";

        var workout = await db.QueryFirstOrDefaultAsync<Workout>(sqlWorkout, new { id });

        if (workout != null)
            workout.Exercises = (await db.QueryAsync<Exercise>(sqlExercises, new { id })).ToList();

        return workout;
    }

    public async Task<IEnumerable<Workout>> GetByStudentAsync(int studentId)
    {
        using var db = new MySqlConnection(_conn);


        var sqlStudents = "SELECT * FROM Workouts WHERE StudentId = @studentId";
        var sqlExercises = "SELECT * FROM Exercises WHERE WorkoutId = @id";

        var workouts = (await db.QueryAsync<Workout>(
            sqlStudents,
            new { studentId }
        )).ToList();

        var exercises = (await db.QueryAsync<Exercise>(
            sqlStudents,
            new { studentId }
        )).ToList();


        return workouts;
    }

    public async Task AddAsync(Workout workout)
    {
        using var db = new MySqlConnection(_conn);

        var sql = "INSERT INTO Workouts (Name, StudentId)" +
                       "VALUES (@Name, @StudentId);" +
                       "SELECT LAST_INSERT_ID();";

        var id = await db.ExecuteScalarAsync<int>(sql, workout);

        if (workout.Exercises != null)
        {
            foreach (var exercise in workout.Exercises)
            {
                exercise.WorkoutId = id;
                await db.ExecuteAsync(
                    @"INSERT INTO Exercises (Name, Repetitions, Sets)
                      VALUES (@Name, @Repetitions, @Sets, @WorkoutId)",
                    exercise
                );
            }
        }
    }
}
