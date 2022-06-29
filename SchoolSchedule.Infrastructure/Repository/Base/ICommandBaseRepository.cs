using SchoolSchedule.Infrastructure.Data.Models;

namespace SchoolSchedule.Infrastructure.Repository.Base;

public interface ICommandBaseRepository<T>
    where T : IdentityBase
{
    Task<Guid> SaveAsync(T newEntity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task RemoveByIdAsync(Guid id);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
