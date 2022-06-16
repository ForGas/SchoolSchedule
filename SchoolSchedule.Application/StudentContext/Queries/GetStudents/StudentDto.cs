namespace SchoolSchedule.Application.StudentContext.Queries.GetStudents;

public class StudentDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public DateOnly BirthYear { get; set; }
}
