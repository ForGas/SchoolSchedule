using SchoolSchedule.Domain.SeedWork;

namespace SchoolSchedule.Domain.EducationalClassAggregate;

public class Student : IdentityBase
{
    private EducationalClass _educationalClass;

    public string FullName { get; init; }
    public DateOnly BirthYear { get; init; }

    public Guid EducationalClassId { get; set; }
    public virtual EducationalClass EducationalClass => _educationalClass;

    public Student(string fullName, DateOnly birthYear)
        => (FullName, BirthYear) = (fullName, birthYear);

    protected Student() { }

    public void EnrollInClass(EducationalClass @class)
    {
        if (@class != null)
        {
            _educationalClass = @class;
            return;
        }

        throw new ArgumentException(nameof(this.EnrollInClass), nameof(@class));
    }
}
