using SchoolSchedule.Domain.SeedWork;

namespace SchoolSchedule.Domain.EducationalClassAggregate.Events;

public class StydentAdmissioned : IDomainEvent
{
    public Guid StudentId { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.Now;

    protected StydentAdmissioned(){}

    public StydentAdmissioned(Student student)
    {
        StudentId = student.Id;
        CreatedAt = DateTime.Now;
    }
}
