using SchoolSchedule.Domain.SeedWork;

namespace SchoolSchedule.Domain.SchoolDayScheduleAggregate;

public class SchoolDaySchedule : IdentityBase
{
    private bool _isActive;
    public SchoolDaySchedule(DateOnly day)
    {
        Day = day;
        _isActive = false;
    }

    protected SchoolDaySchedule() { }

    public DateOnly Day { get; init; }
    public bool IsActive => _isActive;
    public virtual List<Classroom> Classroom { get; set; } = new();

    public void SetActiveSchoolDaySchedule(bool active) => _isActive = active;
}

