using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SchoolSchedule.Domain.EducationalClassAggregate;
using SchoolSchedule.Domain.LessonAggregate;
using SchoolSchedule.Domain.SeedWork;

namespace SchoolSchedule.Infrastructure.Data;

#nullable disable
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IDomainEventDispatcher _dispatcher;
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options, 
        IDomainEventDispatcher dispatcher
        ) : base(options) 
            => (_dispatcher) = (dispatcher);

    public DbSet<Student> Students { get; set; }
    public DbSet<EducationalClass> EducationalClasses { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        await PreSaveChanges();
        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }

    private async Task PreSaveChanges()
    {
        var domainEventEntities = ChangeTracker.Entries<IAggregateRoot>()
            .Select(x => x.Entity)
            .Where(x => x.DomainEvents.Any())
            .ToArray();

        foreach (var entity in domainEventEntities)
        {
            IDomainEvent @event;
            while (entity.DomainEvents.TryTake(out @event))
                await _dispatcher.Dispatch(@event);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
