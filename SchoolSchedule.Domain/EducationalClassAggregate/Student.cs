using SchoolSchedule.Domain.EducationalClassAggregate.Exceptions;

namespace SchoolSchedule.Domain.EducationalClassAggregate;

public class Student
{
    private EducationalClass _educationalClass;
    private readonly string _fullName;


    #region constructors
    public Student(
        Guid id,
        string fullName,
        DateOnly birthYear,
        EducationalClass educationalClass
        )
    {
        if (id == Guid.Empty)
            throw new StudentDomainException("Entity id is empty");

        if (string.IsNullOrEmpty(fullName))
            throw new StudentDomainException("FullName is empty");


        (Id, _fullName, BirthYear, _educationalClass) = (id, fullName, birthYear, educationalClass);
    }
    #endregion

    #region props
    public Guid Id { get; private set; }
    public DateOnly BirthYear { get; init; }
    public Guid EducationalClassId { get; private set; }
    public EducationalClass EducationalClass => _educationalClass;
    public string FullName
    {
        get => _fullName;
        init => _fullName = !string.IsNullOrEmpty(value) ? value : throw new StudentDomainException(nameof(value));
    }
    #endregion

    public void EnrollInClass(EducationalClass @class)
    {
        if (
            @class != null
            && @class.Students.Any(x => x == this))
        {
            _educationalClass = @class;
            return;
        }

        throw new StudentDomainException(nameof(this.EnrollInClass), new ArgumentException($"Entity {@class} is not valid"));
    }
}
