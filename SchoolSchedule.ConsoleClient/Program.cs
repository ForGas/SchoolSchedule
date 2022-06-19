// See https://aka.ms/new-console-template for more information
using SchoolSchedule.Domain.EducationalClassAggregate;
using SchoolSchedule.Domain.LessonAggregate;

Console.WriteLine("Hello, World!");



var student1 = new Student("Test1", DateOnly.FromDateTime(DateTime.UtcNow));
var student2 = new Student("Test2", DateOnly.FromDateTime(DateTime.UtcNow));
var student3 = new Student("Test3", DateOnly.FromDateTime(DateTime.UtcNow));

var @class1 = new EducationalClass("1a");
var @class2 = new EducationalClass("2a");

var subject = Subject.ComputerScience;
var subject2 = Subject.Literature;

Test<Subject>.Equals(subject, subject2);


var teacher = new Teacher(subject, "test");

@class1.EnrollmentStudent(student1);
@class1.EnrollmentStudent(student2);
@class2.EnrollmentStudent(student3);

@class1.AppointClassroomTeacher(teacher);

var lesson1 = new Lesson(subject, teacher, @class1, new TimeOnly(12, 0), new TimeOnly(12, 45));
var lesson2 = new Lesson(subject, teacher, @class1, new TimeOnly(12, 0), new TimeOnly(12, 45));

Test<Lesson>.Equals(lesson1, lesson2);

Console.ReadLine();



public static class Test<T> where T : class
{
    public static void Equals(T subject1, T subject2)
    {
        Console.WriteLine(EqualityComparer<T>.Default.Equals(subject1, subject2));
        Console.WriteLine(object.Equals(subject1, subject2));
        Console.WriteLine(subject1.Equals(subject2));
        Console.WriteLine(subject1 == subject2);
    }
}