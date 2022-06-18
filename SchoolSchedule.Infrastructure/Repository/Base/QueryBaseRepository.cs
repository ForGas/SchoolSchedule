using Microsoft.EntityFrameworkCore;
using SchoolSchedule.Application.Contracts;
using SchoolSchedule.Domain.SeedWork;
using SchoolSchedule.Infrastructure.Data;
using System.Linq.Expressions;

namespace SchoolSchedule.Infrastructure.Repository.Base;

public abstract class QueryBaseRepository<TEntity> : IQueryBaseRepository<TEntity>
    where TEntity : IdentityBase
{
    protected ApplicationDbContext _context;
    protected DbSet<TEntity> _dbSet;

    public QueryBaseRepository(ApplicationDbContext context)
        => (_context, _dbSet) = (context, context.Set<TEntity>());

    public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> selector)
        => _dbSet.Where(selector).AsQueryable();

    public async Task<TEntity> GetByIdAsync(Guid Id)
        => await _dbSet.SingleAsync(x => x.Id == Id);

    public IQueryable<TEntity> GetAll()
        => _dbSet.AsQueryable();
}
