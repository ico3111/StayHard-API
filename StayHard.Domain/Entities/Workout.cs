namespace StayHard.Domain.Entities
{
    public class Workout
    {
        public Workout() { }

        public Workout(string name, int studentId)
        {
            Name = name;
            StudentId = studentId;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int StudentId { get; set; }
    }
}
