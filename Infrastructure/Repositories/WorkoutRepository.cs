using Microsoft.EntityFrameworkCore;
using StayHard.Domain.Entities;
using StayHard.Domain.Interfaces;
using StayHard.Infrastructure.Data;

namespace StayHard.Infrastructure.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly AppDbContext _context;

        public WorkoutRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Workout?> GetByIdAsync(int id)
            => await _context.Workouts
                .Include(w => w.Exercises)
                .FirstOrDefaultAsync(w => w.Id == id);

        public async Task<IEnumerable<Workout>> GetByStudentAsync(int studentId)
            => await _context.Workouts
                .Include(w => w.Exercises)
                .Where(w => w.StudentId == studentId)
                .ToListAsync();

        public async Task AddAsync(Workout workout)
        {
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
        }
    }
}
