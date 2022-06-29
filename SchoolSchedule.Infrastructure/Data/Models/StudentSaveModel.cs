namespace SchoolSchedule.Infrastructure.Data.Models;

public class StudentSaveModel : IdentityBase
{
    public DateOnly BirthYear { get; set; }
    public Guid EducationalClassId { get; set; }
    public virtual EducationalSaveModel EducationalClass { get; set; } = null!;
    public string FullName { get; set; } = null!;
}
