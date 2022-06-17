using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SchoolSchedule.Application.Contracts;

public interface IApplicationDbContext
{
    DatabaseFacade Database { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
