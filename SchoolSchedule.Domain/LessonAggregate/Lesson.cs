using SchoolSchedule.Domain.SeedWork;
using SchoolSchedule.Domain.EducationalClassAggregate;

namespace SchoolSchedule.Domain.LessonAggregate;

public class Lesson : IdentityBase
{
    private readonly TimeOnly _startTime;
    private readonly TimeOnly _endTime;
    private readonly Teacher _teacher = null!;
    private readonly Subject _subject = null!;

    public string SubjectName { get; init; }
    public Classroom Classroom { get; init; }

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
        Classroom classroom,
        TimeOnly startTime,
        TimeOnly endTime
        )
        => (SubjectName, _subject, Teacher, EducationalClass, Classroom, StartTime, EndTime)
            = (subject.ToString(), subject, teacher, educationalClass, classroom, startTime, endTime);

    protected Lesson() { }
}

