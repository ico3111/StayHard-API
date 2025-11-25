namespace StayHard.Domain.Entities
{
    public class Exercise(string name, int repetitions, int sets, int workoutId)
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = name;
        public int Repetitions { get; private set; } = repetitions;
        public int Sets { get; private set; } = sets;
        public int WorkoutId { get; set; } = workoutId;
    }
}
