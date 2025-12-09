namespace StayHard.Application.Domains.Exercises.Models.Entities;

public class Exercise
{
    public int Id { get; set; }
    public string Name { get; private set; }
    public int Sets { get; private set; }
    public int Reps { get; private set; }

    public Exercise() { }

    public Exercise(string name, int sets, int reps) {
        Name = name;
        Sets = sets;
        Reps = reps;
    }


}
