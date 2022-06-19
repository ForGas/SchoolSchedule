using MediatR;
using SchoolSchedule.Domain.SeedWork;

namespace SchoolSchedule.Application.Common;

public class DomainEventNotification<TDomainEvent> : INotification where TDomainEvent : IDomainEvent
{
    public TDomainEvent DomainEvent { get; }

    public DomainEventNotification(TDomainEvent domainEvent)
        => DomainEvent = domainEvent;
}
