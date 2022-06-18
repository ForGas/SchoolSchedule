using SchoolSchedule.Domain.EducationalClassAggregate;

namespace SchoolSchedule.Application.Contracts;

public interface ICommandStudentRepository : ICommandBaseRepository<Student>
{
    Task<Guid> EnrollmentInSchoolAsync(Student student);
}
