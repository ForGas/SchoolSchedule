using SchoolSchedule.Domain.Common;

namespace SchoolSchedule.Domain;

public class Student : IdentityBase
{
    public string FullName { get; init; }
    public DateOnly BirthYear { get; init; }

    public Student(string fullName, DateOnly birthYear)
    {
        FullName = fullName;
        BirthYear = birthYear;
    }
}
