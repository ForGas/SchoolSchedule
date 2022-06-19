namespace SchoolSchedule.Domain.SeedWork;

public interface IDomainEventDispatcher
{
    Task Dispatch(IDomainEvent devent);
}
