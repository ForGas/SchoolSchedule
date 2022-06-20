using SchoolSchedule.Domain.LessonAggregate;
using SchoolSchedule.Domain.SeedWork;

namespace SchoolSchedule.Domain.SchoolDayScheduleAggregate;

public class SchoolDaySchedule : IdentityBase
{
    private bool _isActive;
    private readonly List<Lesson> _lessons = new();

    public SchoolDaySchedule(DateOnly day)
        => (Day, _isActive) = (day, true);

    protected SchoolDaySchedule() { }

    public DateOnly Day { get; init; }
    public bool IsActive => _isActive;
    public virtual IReadOnlyCollection<Lesson> Lessons => _lessons;

    public void SetActiveSchoolDaySchedule(bool active) => _isActive = active;

    private void AddLessonForDaySchedule(Lesson lesson)
    {
        if (
            lesson != null
            && _lessons.All(x => x.Id != x.Id)
            && IsTimeCorrect(lesson)
            )
        {
            _lessons.Add(lesson);
            lesson.SetSchoolDaySchedule(this);
            return;
        }

        throw new ArgumentException(nameof(this.AddLessonForDaySchedule), nameof(lesson));
    }

    private bool IsTimeCorrect(Lesson lesson)
        => !_lessons.Any(x =>
            (x.EndTime >= lesson.EndTime && lesson.EndTime <= x.StartTime)
            || (x.EndTime >= lesson.StartTime && lesson.StartTime <= x.StartTime));
    
}

