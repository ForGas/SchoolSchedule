namespace SchoolSchedule.Domain;

public class EducationalClass
{
    public string Name { get; set; } = null!;
    public virtual List<Student> Students { get; set; } = null!;
    public virtual Teacher ClassroomTeacher { get; set; } = null!;
}

