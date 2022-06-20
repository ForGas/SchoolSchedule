namespace SchoolSchedule.Domain.SeedWork;

public abstract class IdentityBase
{
    public Guid Id { get; init; } = Guid.NewGuid();

}

