using Microsoft.EntityFrameworkCore;
using StayHard.Domain.Entities;

namespace StayHard.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Workout> Workouts => Set<Workout>();
        public DbSet<Exercise> Exercises => Set<Exercise>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Workout>()
                .HasKey(w => w.Id);

            modelBuilder.Entity<Exercise>()
                .HasKey(e => e.Id);

            // Relação: 1 Student → N Workouts
            modelBuilder.Entity<Workout>()
                .HasOne<Student>()
                .WithMany()
                .HasForeignKey(w => w.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relação: 1 Workout → N Exercises
            modelBuilder.Entity<Exercise>()
                .HasOne<Workout>()
                .WithMany(w => w.Exercises)
                .HasForeignKey("WorkoutId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
