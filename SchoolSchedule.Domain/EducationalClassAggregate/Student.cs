using SchoolSchedule.Domain.SeedWork;

namespace SchoolSchedule.Domain.EducationalClassAggregate;

public class Student : IdentityBase
{
    public string FullName { get; init; }
    public DateOnly BirthYear { get; init; }
    public virtual EducationalClass EducationalClass { get; private set; } = null!;

    public Student(string fullName, DateOnly birthYear)
        => (FullName, BirthYear) = (fullName, birthYear);

    public void EnrollInClass(EducationalClass @class)
    {
        if (EducationalClass == null)
        {
            EducationalClass = @class; 
            return;
        }

        throw new ArgumentException(nameof(this.EnrollInClass), nameof(@class));
    }
}
