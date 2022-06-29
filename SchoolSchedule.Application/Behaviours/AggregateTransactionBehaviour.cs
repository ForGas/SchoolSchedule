using MediatR;
using Microsoft.Extensions.Logging;
using SchoolSchedule.Application.Contracts;
using SchoolSchedule.Infrastructure.Data;

namespace SchoolSchedule.Application.Behaviours;

public class AggregateTransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IAggregateTransactionCommand<TResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<AggregateTransactionBehaviour<TRequest, TResponse>> _logger;

    public AggregateTransactionBehaviour(
        IApplicationDbContext context, 
        ILogger<AggregateTransactionBehaviour<TRequest, TResponse>> logger
        ) => (_context, _logger) = (context, logger);

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var response = await next();
            await transaction.CommitAsync(cancellationToken);

            _logger.LogInformation($"Transaction - {transaction.TransactionId} is commited");
            _logger.LogInformation($"Transaction aggregate request - {nameof(request)} {request.GetType().Name}");
            return response;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError($"Transaction - {transaction.TransactionId} was rollback! \n {ex.Message}");
            throw;
        }
    }
}
