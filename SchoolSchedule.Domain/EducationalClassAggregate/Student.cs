using SchoolSchedule.Domain.Common;

namespace SchoolSchedule.Domain.EducationalClassAggregate;

public class Student : IdentityBase
{
    public string FullName { get; init; }
    public DateOnly BirthYear { get; init; }
    public virtual EducationalClass EducationalClass { get; set; } = null!;

    public Student(string fullName, DateOnly birthYear)
    {
        FullName = fullName;
        BirthYear = birthYear;
    }
}
