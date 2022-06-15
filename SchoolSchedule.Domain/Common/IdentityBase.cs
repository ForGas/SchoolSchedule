namespace SchoolSchedule.Domain.Common;

public abstract class IdentityBase : IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
