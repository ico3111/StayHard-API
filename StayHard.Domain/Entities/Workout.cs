namespace StayHard.Domain.Entities
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public List<Exercise>? Exercises { get; set; } = new();

        public Workout() { }

        public Workout(string name, int userId)
        {
            Name = name;
            UserId = userId;
        }
    }

}
