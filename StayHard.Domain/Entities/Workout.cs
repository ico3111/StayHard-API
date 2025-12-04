namespace StayHard.Domain.Entities
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public int UserId { get; set; }
        public List<Exercise>? Exercises { get; set; } = new();

        public Workout() { }

        public Workout(string name, string description, string date, int userId)
        {
            Name = name;
            Description = description;
            Date = date;
            UserId = userId;
        }
    }

}
