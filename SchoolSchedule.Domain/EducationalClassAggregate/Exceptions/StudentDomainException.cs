using SchoolSchedule.Domain.Common;

namespace SchoolSchedule.Domain.EducationalClassAggregate.Exceptions;

public class StudentDomainException : DomainException
{
    public StudentDomainException() { }

    public StudentDomainException(string message) : base(message) { }

    public StudentDomainException(string message, Exception innerException)
        : base(message, innerException) { }
}
