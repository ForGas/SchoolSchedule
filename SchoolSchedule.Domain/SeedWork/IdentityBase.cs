namespace SchoolSchedule.Domain.Common;

public abstract class IdentityBase : IAggregateRoot
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
