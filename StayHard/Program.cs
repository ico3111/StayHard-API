using Microsoft.EntityFrameworkCore;
using StayHard.Application.Interfaces;
using StayHard.Application.Services;
using StayHard.Domain.Interfaces;
using StayHard.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Conexão com MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

// Injeção de dependências
builder.Services.AddScoped<IWorkoutService, WorkoutService>();
builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();

//teste git