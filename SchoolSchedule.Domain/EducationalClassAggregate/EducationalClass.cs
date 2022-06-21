using SchoolSchedule.Domain.SeedWork;
using SchoolSchedule.Domain.LessonAggregate;
using SchoolSchedule.Domain.EducationalClassAggregate.Events;
using SchoolSchedule.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSchedule.Domain.EducationalClassAggregate;

public class EducationalClass : AggregateRoot
{
    private readonly List<Lesson> _lessons = new();
    private readonly List<Student> _students = new();
    private Teacher? _classroomTeacher;

    protected EducationalClass() { }
    public EducationalClass(string name) => Name = name;


    [NotMapped]
    public override AggregateType RootType => AggregateType.EducationalClass;

    public string Name { get; init; } = null!;
    public virtual IReadOnlyCollection<Student> Students => _students;
    public virtual IReadOnlyCollection<Lesson> Lessons => _lessons;
    public virtual Teacher? ClassroomTeacher => _classroomTeacher;

    public void EnrollmentStudentsInClass(List<Student> students)
    {
        if (
            students != null
            && students.Any()
            && students.Count <= Settings.NUMBER_SEATS_IN_CLASS
            && students.All(x => x.EducationalClass == null)
            )
        {
            _students.AddRange(students);

            foreach (var student in students)
            {
                student.EnrollInClass(this);
                PublishEvent(new StydentAdmissioned(this, student));
            }

            return;
        }

        throw new ArgumentException(nameof(this.EnrollmentStudentsInClass), nameof(students));
    }

    public void EnrollmentStudent(Student student)
    {
        if (
            student != null
            && _students.Count <= Settings.NUMBER_SEATS_IN_CLASS
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
            _classroomTeacher.BecomeClassTeacher(this);
            PublishEvent(new ClassTeacherAppointed(this, _classroomTeacher));
            return;
        }

        throw new ArgumentException(nameof(this.AppointClassroomTeacher), nameof(classroomTeacher.EducationalClass));
    }
}

