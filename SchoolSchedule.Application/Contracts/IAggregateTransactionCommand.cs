namespace SchoolSchedule.Application.Contracts;

public interface IAggregateTransactionCommand<out TResponse> : ICommand<TResponse> { }
