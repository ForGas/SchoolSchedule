using SchoolSchedule.Domain.LessonAggregate;
using SchoolSchedule.Domain.SeedWork;

namespace SchoolSchedule.Domain.EducationalClassAggregate.Events;

public class ClassTeacherAppointed : IDomainEvent
{
    public Guid ClassroomTeacherId { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public EducationalClass EducationalClass { get; init; }

    public ClassTeacherAppointed(EducationalClass @class, Teacher classroomTeacher)
    {
        ClassroomTeacherId = classroomTeacher.Id;
        CreatedAt = DateTime.Now;
        EducationalClass = @class;
    }
}
