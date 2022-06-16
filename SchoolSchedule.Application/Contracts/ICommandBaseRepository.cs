using SchoolSchedule.Domain.Common;

namespace SchoolSchedule.Application.Contracts;

public interface ICommandBaseRepository<T>
    where T : class, IAggregateRoot
{
    Task<Guid> SaveAsync(T newEntity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task RemoveByIdAsync(Guid id);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
