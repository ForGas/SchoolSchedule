namespace SchoolSchedule.Infrastructure.Data.Models;

public class TeacherSaveModel : IdentityBase
{
    public string FullName { get; set; } = null!;
    public List<SubjectModel> Subjects { get; set; } = new();
    public Guid? EducationalClassId { get; set; }
    public virtual EducationalSaveModel? EducationalClass { get; set; } = null!;
    public virtual List<LessonModel> Lessons { get; set; }
}
