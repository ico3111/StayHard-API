namespace StayHard.Domain.Entities
{
    public class Exercise
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public int Repetitions { get; private set; }
        public int Sets { get; private set; }

        protected Exercise() { }

        public Exercise(string name, int repetitions, int sets)
        {
            Name = name;
            Repetitions = repetitions;
            Sets = sets;
        }
    }
}
