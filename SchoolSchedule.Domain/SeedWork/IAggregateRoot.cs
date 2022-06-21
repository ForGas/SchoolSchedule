using SchoolSchedule.Domain.Common;
using System.Collections.Concurrent;

namespace SchoolSchedule.Domain.SeedWork;

public interface IAggregateRoot 
{ 
    Guid Id { get; }
    AggregateType RootType { get; }
    IProducerConsumerCollection<IDomainEvent> DomainEvents { get; }
}
