using MediatR;
using Microsoft.Extensions.Logging;
using SchoolSchedule.Domain.SeedWork;

namespace SchoolSchedule.Application.Common;

#nullable disable
public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IPublisher _mediator;
    private readonly ILogger<DomainEventDispatcher> _logger;
    public DomainEventDispatcher(IPublisher mediator, ILogger<DomainEventDispatcher> logger)
        => (_mediator, _logger) = (mediator, logger);

    public async Task Dispatch(IDomainEvent devent)
    {
        var domainEventNotification = CreateDomainEventNotification(devent);
        _logger.LogDebug("Dispatching Domain Event as MediatR notification.  EventType: {eventType}", devent.GetType());
        await _mediator.Publish(domainEventNotification);
    }

    private INotification CreateDomainEventNotification(IDomainEvent domainEvent)
        => (INotification)Activator.CreateInstance(
                typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent);
    
}
