using SchoolSchedule.Domain.Common;

namespace SchoolSchedule.Domain.EducationalClassAggregate.Exceptions;

public class EducationalClassDomainException : DomainException
{
    public EducationalClassDomainException() { }

    public EducationalClassDomainException(string message) : base(message) { }

    public EducationalClassDomainException(string message, Exception innerException)
        : base(message, innerException) { }
}