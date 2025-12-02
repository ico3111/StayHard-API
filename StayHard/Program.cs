using MySqlConnector;
using StayHard.Application.Interfaces;
using StayHard.Application.Services;
using StayHard.Domain.Interfaces;
using StayHard.Infrastructure.Repositories;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Conexão com MySQL
builder.Services.AddTransient<IDbConnection>(sp =>
{
    var conn = new MySqlConnection(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );

    return conn;
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Injeção de dependências
builder.Services.AddScoped<IWorkoutService, WorkoutService>();
builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.UseCors(); 
app.MapControllers();
app.MapControllers();

app.Run();

//teste git