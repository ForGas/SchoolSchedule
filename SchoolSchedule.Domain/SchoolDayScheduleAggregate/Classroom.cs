using SchoolSchedule.Domain.SeedWork;

namespace SchoolSchedule.Domain.LessonAggregate;

public class Classroom : ValueObject
{
    public string Number { get; init; }

    public Classroom(string number) => Number = number;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Number;
    }
}

