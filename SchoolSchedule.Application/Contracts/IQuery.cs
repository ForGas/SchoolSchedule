using MediatR;

namespace SchoolSchedule.Application.Contracts;

public interface IQuery<out TResponse> : IRequest<TResponse> { }
