using SchoolSchedule.Domain.Common;

namespace SchoolSchedule.Domain;

public class Teacher : IdentityBase
{
    public string FullName { get; init; }
    public virtual List<Subject> Subjects { get; init; }

    public Teacher(List<Subject> subjects, string fullName)
        => (Subjects, FullName) = (subjects, fullName);

    public void AddTeachingSubjects(List<Subject> subjects)
    {
        if (subjects != null && Subjects.Any() && !Subjects.HasDuplications())
        {
            Subjects.AddRange(subjects);
        }
    }
}

