namespace StayHard.Domain.Entities
{
    public class Workout
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public int StudentId { get; private set; }
        public List<Exercise> Exercises { get; private set; } = new();

        protected Workout() { }

        public Workout(string name, int studentId)
        {
            Name = name;
            StudentId = studentId;
        }

        public void AddExercise(string name, int repetitions, int sets)
        {
            Exercises.Add(new Exercise(name, repetitions, sets));
        }
    }
}
