using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSchedule.Domain.SeedWork;

public abstract class IdentityBase : IAggregateRoot
{
    public Guid Id { get; init; } = Guid.NewGuid();

    [NotMapped]
    private readonly ConcurrentQueue<IDomainEvent> _domainEvents = new();

    [NotMapped]
    public IProducerConsumerCollection<IDomainEvent> DomainEvents => _domainEvents;

    protected void PublishEvent(IDomainEvent @event) => _domainEvents.Enqueue(@event);
}
