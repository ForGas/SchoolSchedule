using SchoolSchedule.Domain.EducationalClassAggregate;
using SchoolSchedule.Infrastructure.Data;
using SchoolSchedule.Infrastructure.Data.Models;
using SchoolSchedule.Infrastructure.Repository.Base;
using SchoolSchedule.Infrastructure.Repository.Shared.Student.Abstractions;

namespace SchoolSchedule.Infrastructure.Repository;

public class CommandStudentRepository : CommandBaseRepository<StudentSaveModel>, ICommandStudentRepository
{
    public CommandStudentRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Guid> EnrollmentInSchoolAsync(Student student)
    {
        throw new NotImplementedException();
    }
}
