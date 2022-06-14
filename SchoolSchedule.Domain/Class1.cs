using SchoolSchedule.Domain.Common;

namespace SchoolSchedule.Domain;

public abstract class IdentityBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
}

public class Cabinet
{

}


public class Classroom : IdentityBase
{

}


public class Teacher : IdentityBase
{

}

public class Lesson : ValueObject
{
    public string Name { get; private set; }

    static Lesson() { }

    private Lesson() { }

    private Lesson(string name) => Name = name;

    public static Lesson Math => new("Math");
    public static Lesson Physics => new("Physics");
    public static Lesson Literature => new("Literature");
    public static Lesson ComputerScience => new("ComputerScience");
    public static Lesson PhysicalEducation  => new("PhysicalEducation");

    public override string ToString() => Name;

    public static implicit operator string(Lesson lesson) => lesson.ToString();

    public static explicit operator Lesson(string name)
        => !Lessons.Contains(new Lesson(name)) 
            ? throw new ArgumentException(name)
            : new Lesson(name);
    
    protected static IEnumerable<Lesson> Lessons
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

public class SchoolSchedule
{

}


