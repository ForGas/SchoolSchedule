using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SchoolSchedule.Domain.EducationalClassAggregate;
using SchoolSchedule.Domain.LessonAggregate;

namespace SchoolSchedule.Application.Contracts;

public interface IApplicationDbContext
{
    DatabaseFacade Database { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    DbSet<Student> Students { get; set; }
    DbSet<EducationalClass> EducationalClasses { get; set; }
    DbSet<Teacher> Teachers { get; set; }
}
