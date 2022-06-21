namespace SchoolSchedule.Application.Features.EducationalClass.Queries;

public class StudentDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public DateOnly BirthYear { get; set; }
}
