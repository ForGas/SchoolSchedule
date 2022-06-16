using SchoolSchedule.Application.Contracts;
using SchoolSchedule.Domain;
using SchoolSchedule.Infrastructure.Data;

namespace SchoolSchedule.Infrastructure.Services;

public class QueryStudentRepository : QueryBaseRepository<Student>, IQueryStudentRepository
{
    public QueryStudentRepository(ApplicationDbContext context) : base(context)
    {
    }
}
