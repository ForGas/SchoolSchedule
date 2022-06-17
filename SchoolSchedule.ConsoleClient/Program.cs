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

var teacher = new Teacher(subject, "test");


@class1.EnrollmentStudent(student1);
@class1.EnrollmentStudent(student2);
@class2.EnrollmentStudent(student3);

@class1.AppointClassroomTeacher(teacher);



Console.ReadLine();
