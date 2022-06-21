using SchoolSchedule.Domain.Common;
using SchoolSchedule.Domain.SeedWork;

namespace SchoolSchedule.Domain.LessonAggregate;

public class Subject : ValueObject
{
    public string Name { get; init; }

    static Subject() { }
    protected Subject() { }
    private Subject(string name) => Name = name;

    public static Subject Math => new(Settings.COMPUTERSCIENCE_SUBJECT_NAME);
    public static Subject Physics => new(Settings.PHYSICS_SUBJECT_NAME);
    public static Subject Literature => new(Settings.LITERATURE_SUBJECT_NAME);
    public static Subject ComputerScience => new(Settings.COMPUTERSCIENCE_SUBJECT_NAME);
    public static Subject PhysicalEducation => new(Settings.PHYSICALEDUCATION_SUBJECT_NAME);

    public override string ToString() => Name;

    public static implicit operator string(Subject subject) => subject.ToString();

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