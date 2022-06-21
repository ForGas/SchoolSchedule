using MediatR;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace SchoolSchedule.Application.Behaviours;

#nullable disable
public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        => _logger = logger;

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        _logger.LogInformation($"{DateTimeOffset.UtcNow.ToString("G")} - Handling {typeof(TRequest).Name}");

        Type myType = request.GetType();
        IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

        foreach (PropertyInfo prop in props)
        {
            object propValue = prop.GetValue(request, null);
            _logger.LogInformation("{Property} : {@Value}", prop.Name, propValue);
        }

        var response = await next();
        
        _logger.LogInformation($"{DateTimeOffset.UtcNow.ToString("G")} - Handled {typeof(TResponse).Name}");
        return response;
    }
}
