using SchoolSchedule.Domain.Common;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSchedule.Domain.SeedWork;

public abstract class AggregateRoot : IdentityBase, IAggregateRoot
{
    [NotMapped]
    private readonly ConcurrentQueue<IDomainEvent> _domainEvents = new();

    [NotMapped]
    public IProducerConsumerCollection<IDomainEvent> DomainEvents => _domainEvents;

    public virtual AggregateType RootType => AggregateType.NoDefinition;

    protected void PublishEvent(IDomainEvent @event) => _domainEvents.Enqueue(@event);
}

