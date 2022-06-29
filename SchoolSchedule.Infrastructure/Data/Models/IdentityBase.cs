namespace SchoolSchedule.Infrastructure.Data.Models;

public abstract class IdentityBase
{
    public Guid Id { get; init; } = Guid.NewGuid();
}
