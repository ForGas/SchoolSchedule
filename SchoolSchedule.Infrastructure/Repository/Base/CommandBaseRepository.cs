using Microsoft.EntityFrameworkCore;
using SchoolSchedule.Application.Contracts;
using SchoolSchedule.Domain.Common;
using SchoolSchedule.Infrastructure.Data;

namespace SchoolSchedule.Infrastructure.Repository.Base;

public abstract class CommandBaseRepository<TEntity> : ICommandBaseRepository<TEntity>
    where TEntity : IdentityBase
{
    protected ApplicationDbContext _context;
    protected DbSet<TEntity> _dbSet;

    public CommandBaseRepository(ApplicationDbContext context)
        => (_context, _dbSet) = (context, context.Set<TEntity>());

    public async Task DeleteAsync(TEntity entity)
        => await Task.Run(() => _dbSet.Remove(entity));

    public async Task RemoveByIdAsync(Guid id)
        => await DeleteAsync(_dbSet.Find(id) ?? throw new ArgumentNullException(nameof(id)));

    public async Task<Guid> SaveAsync(TEntity newEntity)
    {
        var entity = await _dbSet.AddAsync(newEntity);
        return entity.Entity.Id;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);

    public async Task UpdateAsync(TEntity entity)
        => await Task.Run(() => _dbSet.Update(entity));
}
