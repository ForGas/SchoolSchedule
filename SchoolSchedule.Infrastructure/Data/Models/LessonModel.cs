namespace SchoolSchedule.Infrastructure.Data.Models;

public class LessonModel
{
    public string SubjectName { get; set; } = null!;
    public virtual ClassroomModel Classroom { get; set; } = null!;
    public bool IsActive { get; set; }
    public SubjectModel Subject { get; set; } = null!;
    public Guid EducationalClassId { get; set; }
    public Guid SchoolDayScheduleId { get; set; }
    public virtual SchoolDayScheduleSaveModel SchoolDaySchedule { get; set; } = null!;
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public virtual TeacherSaveModel Teacher { get; set; } = null!;
}
