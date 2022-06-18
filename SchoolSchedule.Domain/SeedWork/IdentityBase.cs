namespace SchoolSchedule.Domain.SeedWork;

public abstract class IdentityBase : IAggregateRoot
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
