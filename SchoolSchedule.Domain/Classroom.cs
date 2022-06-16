using SchoolSchedule.Domain.Common;

namespace SchoolSchedule.Domain;

public class Classroom : IdentityBase
{
    public int Number { get; set; }
    public virtual List<Lesson> Lessons { get; set; } = null!;
}

