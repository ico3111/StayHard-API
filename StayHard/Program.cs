using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MySqlConnector;
using StayHard.Application.Domains.Exercises.Queries;
using StayHard.Application.Domains.Exercises.Services;
using StayHard.Application.Domains.Users.Queries;
using StayHard.Application.Domains.Workouts.Queries;
using System.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Conexão com MySQL
builder.Services.AddTransient<IDbConnection>(sp =>
{
    var conn = new MySqlConnection(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );

    return conn;
});

// Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("StayHardPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Configuração de Autenticação
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false, // Em DEV
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AiMinhasCoxtaNoMesmoLugar2025cont123456789"))
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["stay-hard-auth"];
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();

// Injeção de dependências
builder.Services.AddScoped<IWorkoutQueries, WorkoutQueries>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IExerciseQueries, ExerciseQueries>();
builder.Services.AddScoped<IUserQueries, UserQueries>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseCors("StayHardPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();