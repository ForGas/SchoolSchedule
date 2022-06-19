using System.Collections.Concurrent;

namespace SchoolSchedule.Domain.SeedWork;

public interface IAggregateRoot 
{ 
    Guid Id { get; }
    IProducerConsumerCollection<IDomainEvent> DomainEvents { get; }
}
