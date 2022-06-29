using SchoolSchedule.Infrastructure.Data;
using SchoolSchedule.Infrastructure.Data.Models;
using SchoolSchedule.Infrastructure.Repository.Base;
using SchoolSchedule.Infrastructure.Repository.Shared.Student.Abstractions;

namespace SchoolSchedule.Infrastructure.Repository;

public class QueryStudentRepository : QueryBaseRepository<StudentSaveModel>, IQueryStudentRepository
{
    public QueryStudentRepository(ApplicationDbContext context) : base(context)
    {
    }
}
