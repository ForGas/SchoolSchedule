using SchoolSchedule.Domain.SeedWork;

namespace SchoolSchedule.Domain.EducationalClassAggregate.Events;

public class StydentAdmissioned : IDomainEvent
{
    public Guid StudentId { get; init; }
    public Guid EducationalClassId { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.Now;

    public StydentAdmissioned(Student student, EducationalClass @class)
    {
        StudentId = student.Id;
        EducationalClassId = @class.Id;
        CreatedAt = DateTime.Now;
    }
}
