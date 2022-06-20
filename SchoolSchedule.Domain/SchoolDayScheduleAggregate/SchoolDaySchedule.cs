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
}

