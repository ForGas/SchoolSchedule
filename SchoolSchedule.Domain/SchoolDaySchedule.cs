using SchoolSchedule.Domain.Common;

namespace SchoolSchedule.Domain;

public class SchoolDaySchedule : IdentityBase
{
    public DateOnly ScheduleDate { get; set; }
    public bool IsActive { get; set; }
    public virtual List<Classroom> Classroom { get; set; } = new();
}

