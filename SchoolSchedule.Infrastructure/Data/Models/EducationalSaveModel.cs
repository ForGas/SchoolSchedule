namespace SchoolSchedule.Infrastructure.Data.Models;

public class EducationalSaveModel : IdentityBase
{
    public string Name { get; set; } = null!;
    public virtual List<StudentSaveModel> Students { get; set; }
    public virtual List<LessonModel> Lessons { get; set; }
    public virtual TeacherSaveModel? ClassroomTeacher { get; set; }
}
