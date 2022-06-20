using MediatR;

namespace SchoolSchedule.Application.Contracts;

public interface ICommand<out TResponse> : IRequest<TResponse> { }
