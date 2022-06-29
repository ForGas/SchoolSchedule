using SchoolSchedule.Domain.EducationalClassAggregate;
using SchoolSchedule.Infrastructure.Data.Models;
using SchoolSchedule.Infrastructure.Repository.Base;

namespace SchoolSchedule.Infrastructure.Repository.Shared.Student.Abstractions;

public interface IQueryStudentRepository : IQueryBaseRepository<StudentSaveModel>
{

}
