using SchoolSchedule.Domain.SeedWork;
using SchoolSchedule.Domain.LessonAggregate;

namespace SchoolSchedule.Domain.EducationalClassAggregate;

public class EducationalClass : IdentityBase
{
    private readonly List<Lesson> _lessons = new();
    private readonly List<Student> _students = new();
    private Teacher _classroomTeacher;

    public string Name { get; init; } = null!;
    public virtual IReadOnlyCollection<Student> Students => _students;
    public virtual IReadOnlyCollection<Lesson> Lessons => _lessons;

    public virtual Teacher ClassroomTeacher => _classroomTeacher;

    public EducationalClass(string name) => Name = name;

    protected EducationalClass() { }

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
        if (
            classroomTeacher.EducationalClass == null 
            && classroomTeacher.EducationalClassId == null
            )
        {
            _classroomTeacher = classroomTeacher;
            return;
        }

        throw new ArgumentException(nameof(this.AppointClassroomTeacher), nameof(classroomTeacher.EducationalClass));
    }
}

