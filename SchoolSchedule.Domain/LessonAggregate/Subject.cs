using SchoolSchedule.Domain.SeedWork;

namespace SchoolSchedule.Domain.LessonAggregate;

public class Subject : ValueObject
{
    public string Name { get; init; }
    static Subject() { }
    private Subject(string name) => Name = name;

    public static Subject Math => new("Math");
    public static Subject Physics => new("Physics");
    public static Subject Literature => new("Literature");
    public static Subject ComputerScience => new("ComputerScience");
    public static Subject PhysicalEducation => new("PhysicalEducation");

    public override string ToString() => Name;

    public static implicit operator string(Subject Sesson) => Sesson.ToString();

    public static explicit operator Subject(string name)
        => !Subjects.Contains(new Subject(name))
            ? throw new ArgumentException(name)
            : new Subject(name);

    protected static IEnumerable<Subject> Subjects
    {
        get
        {
            yield return Math;
            yield return Physics;
            yield return Literature;
            yield return ComputerScience;
            yield return PhysicalEducation;
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }
}