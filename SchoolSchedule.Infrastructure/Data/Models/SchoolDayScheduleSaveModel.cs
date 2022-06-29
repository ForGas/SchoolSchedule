namespace SchoolSchedule.Infrastructure.Data.Models;

public class SchoolDayScheduleSaveModel : IdentityBase
{
    public DateOnly Day { get; set; }
    public bool IsActive { get; set; }
    public virtual List<LessonModel> Lessons { get; set; }
}
