using SchoolSchedule.Domain.SeedWork;

namespace SchoolSchedule.Application.Contracts;

public interface ICommandBaseRepository<T>
    where T : IdentityBase
{
    Task<Guid> SaveAsync(T newEntity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task RemoveByIdAsync(Guid id);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
