using Microsoft.EntityFrameworkCore;
using StayHard.Domain.Entities;

namespace StayHard.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
