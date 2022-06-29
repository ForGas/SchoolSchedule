using SchoolSchedule.Domain.Common;
using System.Collections.Concurrent;

namespace SchoolSchedule.Domain.SeedWork;

public abstract class AggregateRoot : IAggregateRoot
{
    private readonly ConcurrentQueue<IDomainEvent> _domainEvents = new();

    public IProducerConsumerCollection<IDomainEvent> DomainEvents => _domainEvents;

    public virtual AggregateType RootType => AggregateType.NoDefinition;

    protected void PublishEvent(IDomainEvent @event) => _domainEvents.Enqueue(@event);
}

