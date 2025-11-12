namespace StayHard.Domain.Entities
{
    public class Student
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public DateTime BirthDate { get; private set; }

        protected Student() { }

        public Student(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
    }
}
