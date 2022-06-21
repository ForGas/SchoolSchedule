using SchoolSchedule.Domain.Common;
using SchoolSchedule.Domain.LessonAggregate;
using SchoolSchedule.Domain.SeedWork;

namespace SchoolSchedule.Domain.EducationalClassAggregate.Events;

public class ClassTeacherAppointed : IDomainEvent
{
    public Guid EventId { get; init; } = Guid.NewGuid();
    public Guid AggregateId { get; init; }
    public Guid ClassroomTeacherId { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public AggregateType AggregateType { get; init; }
    public EducationalClass EducationalClass { get; init; }

    public ClassTeacherAppointed(EducationalClass @class, Teacher classroomTeacher)
    {
        AggregateId = @class.Id;
        AggregateType = @class.RootType;
        ClassroomTeacherId = classroomTeacher.Id;
        CreatedAt = DateTime.Now;
        EducationalClass = @class;
    }
}
