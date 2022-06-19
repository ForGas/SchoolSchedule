using SchoolSchedule.Domain.SeedWork;
using SchoolSchedule.Domain.LessonAggregate;

namespace SchoolSchedule.Domain.SchoolDayScheduleAggregate;

public class Classroom : IdentityBase
{
    private readonly HashSet<Lesson> _lessons = new();

    public Classroom(int number)
        => Number = number;

    protected Classroom() { }

    public int Number { get; init; }
    public virtual IReadOnlyCollection<Lesson> Lessons => _lessons;
}

