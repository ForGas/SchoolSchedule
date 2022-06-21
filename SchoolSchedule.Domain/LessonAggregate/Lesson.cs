using SchoolSchedule.Domain.SeedWork;
using SchoolSchedule.Domain.EducationalClassAggregate;
using SchoolSchedule.Domain.SchoolDayScheduleAggregate;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolSchedule.Domain.Common;

namespace SchoolSchedule.Domain.LessonAggregate;

public class Lesson : AggregateRoot
{
    private bool _isActive;
    private readonly TimeOnly _startTime;
    private readonly TimeOnly _endTime;
    private readonly Teacher _teacher = null!;
    private readonly Subject _subject = null!;
    private SchoolDaySchedule _schoolDaySchedule;

    protected Lesson() { }
    public Lesson(
        Subject subject,
        Teacher teacher,
        EducationalClass educationalClass,
        Classroom classroom,
        TimeOnly startTime,
        TimeOnly endTime
        ) => (SubjectName, _subject, Teacher, EducationalClass, Classroom, StartTime, EndTime, _isActive)
            = (subject.ToString(), subject, teacher, educationalClass, classroom, startTime, endTime, true);

    [NotMapped]
    public override AggregateType RootType => AggregateType.Lesson;
    public string SubjectName { get; init; }
    public Classroom Classroom { get; init; }
    public bool IsActive => _isActive;
    public Subject Subject => _subject;
    public virtual EducationalClass EducationalClass { get; init; }
    public virtual SchoolDaySchedule SchoolDaySchedule => _schoolDaySchedule;
    public TimeOnly StartTime { get => _startTime; init => _startTime = value; }
    public TimeOnly EndTime
    {
        get => _endTime;
        init => _endTime = value > _startTime ? value : throw new ArgumentException(nameof(_startTime));
    }
    public virtual Teacher Teacher
    {
        get => _teacher;
        init => _teacher = value.Subjects.Any(x => x == _subject) ? value : throw new ArgumentException(nameof(value));
    }

    public void SetIsLessonDaySchedule(bool active) => _isActive = active;

    public void SetSchoolDaySchedule(SchoolDaySchedule schoolDaySchedule)
    {
        if (schoolDaySchedule.Lessons.Any(x => x == this))
        {
            _schoolDaySchedule = schoolDaySchedule;
        }

        throw new ArgumentException(nameof(this.SetSchoolDaySchedule), nameof(schoolDaySchedule.Lessons));
    }
}