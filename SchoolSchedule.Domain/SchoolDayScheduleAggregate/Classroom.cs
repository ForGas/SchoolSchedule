using SchoolSchedule.Domain.Common;
using SchoolSchedule.Domain.LessonAggregate;

namespace SchoolSchedule.Domain.SchoolDayScheduleAggregate;

public class Classroom : IdentityBase
{
    public int Number { get; set; }
    public virtual List<Lesson> Lessons { get; set; } = null!;
}

