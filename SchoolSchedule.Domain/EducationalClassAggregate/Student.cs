using SchoolSchedule.Domain.SeedWork;

namespace SchoolSchedule.Domain.EducationalClassAggregate;

public class Student : IdentityBase
{
    private EducationalClass _educationalClass;
    private readonly string _fullName;

    protected Student() { }
    public Student(string fullName, DateOnly birthYear)
        => (FullName, BirthYear) = (fullName, birthYear);

    public DateOnly BirthYear { get; init; }
    public Guid EducationalClassId { get; set; }
    public virtual EducationalClass EducationalClass => _educationalClass;
    public string FullName 
    {
        get => _fullName;
        init => _fullName = !string.IsNullOrEmpty(value) ? value : throw new ArgumentNullException(nameof(value));
    }

    public void EnrollInClass(EducationalClass @class)
    {
        if (@class != null)
        {
            _educationalClass = @class;
            return;
        }

        throw new ArgumentNullException(nameof(this.EnrollInClass), nameof(@class));
    }
}
