using SchoolSchedule.Domain.SeedWork;
using SchoolSchedule.Domain.LessonAggregate;

namespace SchoolSchedule.Domain.EducationalClassAggregate;

public class EducationalClass : IdentityBase
{
    private readonly List<Student> _students = new();

    public string Name { get; init; } = null!;
    public virtual IReadOnlyCollection<Student> Students => _students;
    public virtual Teacher ClassroomTeacher { get; private set; } = null!;

    public EducationalClass(string name) => Name = name;

    public void EnrollmentStudentsInClass(List<Student> students)
    {
        if (
            students != null
            && students.Any()
            && students.Count <= 30
            && students.All(x => x.EducationalClass == null)
            )
        {
            _students.AddRange(students);

            foreach (var student in students)
            {
                student.EnrollInClass(this);
            }

            return;
        }

        throw new ArgumentException(nameof(this.EnrollmentStudentsInClass), nameof(students));
    }

    public void EnrollmentStudent(Student student)
    {
        if (
            student != null
            && _students.Count <= 30
            && student.EducationalClass == null
            )
        {
            _students.Add(student);
            student.EnrollInClass(this);
            return;
        }

        throw new ArgumentException(nameof(this.EnrollmentStudent), nameof(student));
    }

    public void AppointClassroomTeacher(Teacher classroomTeacher)
    {
        if (classroomTeacher.EducationalClass == null)
        {
            ClassroomTeacher = classroomTeacher;
            return;
        }

        throw new ArgumentException(nameof(this.AppointClassroomTeacher), nameof(classroomTeacher.EducationalClass));
    }
}

