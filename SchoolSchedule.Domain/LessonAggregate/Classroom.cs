using SchoolSchedule.Domain.SeedWork;

namespace SchoolSchedule.Domain.LessonAggregate;

public class Classroom : ValueObject
{
    public Classroom(int number)
        => Number = number;

    protected Classroom() { }

    public int Number { get; init; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Number;
    }
}

