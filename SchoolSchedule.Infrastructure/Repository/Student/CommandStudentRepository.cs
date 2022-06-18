using SchoolSchedule.Application.Contracts;
using SchoolSchedule.Domain.EducationalClassAggregate;
using SchoolSchedule.Infrastructure.Data;
using SchoolSchedule.Infrastructure.Repository.Base;

namespace SchoolSchedule.Infrastructure.Repository
{
    public class CommandStudentRepository : CommandBaseRepository<Student>, ICommandStudentRepository
    {
        public CommandStudentRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Guid> EnrollmentInSchoolAsync(Student student)
        {
            var result = await SaveAsync(student);
            _ = await SaveChangesAsync(new CancellationToken());
            return result;
        }
    }
}
