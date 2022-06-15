using SchoolSchedule.Domain.Common;

namespace SchoolSchedule.Domain;


public class Classroom : IdentityBase
{
    public int Number { get; set; }
    public virtual List<Lesson> Lessons { get; set; } = null!;
}

public class Student : IdentityBase
{
    public string FullName { get; init; }
    public DateOnly BirthYear { get; init; }

    public Student(string fullName, DateOnly birthYear)
    {
        FullName = fullName;
        BirthYear = birthYear;
    }
}


public class Teacher : IdentityBase
{
    public string FullName { get; init; }
    public virtual List<Subject> Subjects { get; init; }

    public Teacher(List<Subject> subjects, string fullName)
        => (Subjects, FullName) = (subjects, fullName);

    public void AddTeachingSubjects(List<Subject> subjects)
    {
        if (subjects != null && Subjects.Any() && !Subjects.HasDuplications())
        {
            Subjects.AddRange(subjects);
        }
    }
}

public class EducationalClass
{
    public string Name { get; set; } = null!;
    public virtual List<Student> Students { get; set; } = null!;
    public virtual Teacher ClassroomTeacher { get; set; } = null!;
}

public class Lesson : ValueObject
{
    private readonly TimeOnly _startTime;
    private readonly TimeOnly _endTime;
    private readonly Teacher _teacher = null!;
    private readonly Subject _subject = null!;

    public string SubjectName { get; init; }
    public virtual EducationalClass EducationalClass { get; init; }

    public virtual Teacher Teacher
    {
        get => _teacher;
        init => _teacher = value.Subjects.Any(x => x == _subject) ? value : throw new ArgumentException(nameof(value));
    }

    public TimeOnly StartTime { get => _startTime; init => _startTime = value; }
    public TimeOnly EndTime
    {
        get => _endTime;
        init => _endTime = value > _startTime ? value : throw new ArgumentException(nameof(_startTime));
    }

    public Lesson(
        Subject subject,
        Teacher teacher,
        EducationalClass educationalClass,
        TimeOnly startTime,
        TimeOnly endTime
        )
        => (SubjectName, Teacher, EducationalClass, StartTime, EndTime)
            = (subject.ToString(), teacher, educationalClass, startTime, endTime);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return SubjectName;
        yield return Teacher.FullName;
        yield return EducationalClass.Name;
        yield return StartTime;
        yield return EndTime;
    }
}

public class SchoolSchedule : IdentityBase
{
    public DateOnly ScheduleDate { get; set; }
    public bool IsActive { get; set; }
    public virtual List<Classroom> Classroom { get; set; } = new();
}


public static class SchoolScheduleFactory
{
    public static SchoolSchedule CreateSchoolSchedule(SchoolScheduleDto schoolScheduleDto)
    {
        var schoolSchedule = new SchoolSchedule();



        return schoolSchedule;
    }
}

public class SchoolScheduleDto
{

}

