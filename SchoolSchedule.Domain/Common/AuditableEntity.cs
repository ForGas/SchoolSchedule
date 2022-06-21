using SchoolSchedule.Domain.SeedWork;

namespace SchoolSchedule.Domain.Common;

public class AuditableEntity : IdentityBase
{
    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
}
