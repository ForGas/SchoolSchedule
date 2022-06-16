using SchoolSchedule.Domain.Common;

namespace SchoolSchedule.Domain.SchoolDayScheduleAggregate;

public class SchoolDaySchedule : IdentityBase
{
    public DateOnly Day { get; set; }
    public bool IsActive { get; set; }
    public virtual List<Classroom> Classroom { get; set; } = new();
}

