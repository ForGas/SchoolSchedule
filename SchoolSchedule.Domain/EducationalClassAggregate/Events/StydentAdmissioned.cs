using SchoolSchedule.Domain.Common;
using SchoolSchedule.Domain.SeedWork;

namespace SchoolSchedule.Domain.EducationalClassAggregate.Events;

public class StydentAdmissioned : IDomainEvent
{
    public Guid EventId { get; init; } = Guid.NewGuid();
    public Guid AggregateId { get; init; }
    public AggregateType AggregateType { get; init; }
    public Guid StudentId { get; init; }
    public Guid EducationalClassId { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public EducationalClass EducationalClass { get; init; }

    public StydentAdmissioned(EducationalClass @class, Student student)
    {
        AggregateId = @class.Id;
        StudentId = student.Id;
        EducationalClass = @class;
        CreatedAt = DateTime.Now;
        AggregateType = @class.RootType;
    }
}
