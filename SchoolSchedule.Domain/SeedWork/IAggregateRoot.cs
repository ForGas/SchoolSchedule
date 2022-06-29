using SchoolSchedule.Domain.Common;
using System.Collections.Concurrent;

namespace SchoolSchedule.Domain.SeedWork;

public interface IAggregateRoot 
{ 
    AggregateType RootType { get; }
    IProducerConsumerCollection<IDomainEvent> DomainEvents { get; }
}
