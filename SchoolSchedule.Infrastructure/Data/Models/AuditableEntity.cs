namespace SchoolSchedule.Infrastructure.Data.Models;

public class AuditableEntity
{
    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
}
