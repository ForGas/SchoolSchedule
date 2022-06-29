using SchoolSchedule.Domain.SeedWork;
using SchoolSchedule.Domain.EducationalClassAggregate;
using SchoolSchedule.Domain.SchoolDayScheduleAggregate;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolSchedule.Domain.Common;

namespace SchoolSchedule.Domain.LessonAggregate;

public class Lesson : ValueObject
{
    private bool _isActive;
    private readonly TimeOnly _startTime;
    private readonly TimeOnly _endTime;
    private readonly Teacher _teacher = null!;
    private readonly Subject _subject = null!;
    private SchoolDaySchedule _schoolDaySchedule;

    public Lesson(
        Subject subject,
        Teacher teacher,
        Guid educationalClassId,
        Classroom classroom,
        TimeOnly startTime,
        TimeOnly endTime
        ) => (SubjectName, _subject, Teacher, EducationalClassId, Classroom, StartTime, EndTime, _isActive)
            = (subject.ToString(), subject, teacher, educationalClassId, classroom, startTime, endTime, true);

    public string SubjectName { get; init; }
    public Classroom Classroom { get; init; }
    public bool IsActive { get => _isActive; protected set => _isActive = value;}
    public Subject Subject => _subject;
    public Guid EducationalClassId { get; init; }
    public Guid SchoolDayScheduleId { get; protected set; }
    public SchoolDaySchedule SchoolDaySchedule => _schoolDaySchedule;
    public TimeOnly StartTime { get => _startTime; init => _startTime = value; }
    public TimeOnly EndTime
    {
        get => _endTime;
        init => _endTime = value > _startTime ? value : throw new ArgumentException(nameof(_startTime));
    }
    public Teacher Teacher
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

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}