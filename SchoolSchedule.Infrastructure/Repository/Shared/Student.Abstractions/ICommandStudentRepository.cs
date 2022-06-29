using SchoolSchedule.Infrastructure.Data.Models;
using SchoolSchedule.Infrastructure.Repository.Base;

namespace SchoolSchedule.Infrastructure.Repository.Shared.Student.Abstractions;

public interface ICommandStudentRepository : ICommandBaseRepository<StudentSaveModel>
{
    Task<Guid> EnrollmentInSchoolAsync(Domain.EducationalClassAggregate.Student student);
}
