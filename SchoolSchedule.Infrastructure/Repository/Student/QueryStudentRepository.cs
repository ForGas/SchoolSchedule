using SchoolSchedule.Application.Contracts;
using SchoolSchedule.Domain.EducationalClassAggregate;
using SchoolSchedule.Infrastructure.Data;
using SchoolSchedule.Infrastructure.Repository.Base;

namespace SchoolSchedule.Infrastructure.Repository;

public class QueryStudentRepository : QueryBaseRepository<Student>, IQueryStudentRepository
{
    public QueryStudentRepository(ApplicationDbContext context) : base(context)
    {
    }
}
