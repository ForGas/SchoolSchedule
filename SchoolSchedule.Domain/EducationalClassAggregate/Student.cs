using SchoolSchedule.Domain.EducationalClassAggregate.Events;
using SchoolSchedule.Domain.SeedWork;

namespace SchoolSchedule.Domain.EducationalClassAggregate;

public class Student : IdentityBase
{
    private EducationalClass _educationalClass;
    private readonly string _fullName;

    public string FullName 
    {
        get => _fullName;
        init => _fullName = !string.IsNullOrEmpty(value) ? value : throw new ArgumentNullException(nameof(value));
    }

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
            PublishEvent(new StydentAdmissioned(this));
            return;
        }

        throw new ArgumentNullException(nameof(this.EnrollInClass), nameof(@class));
    }
}
