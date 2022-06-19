﻿using SchoolSchedule.Domain.SeedWork;
using SchoolSchedule.Domain.EducationalClassAggregate;

namespace SchoolSchedule.Domain.LessonAggregate;

public class Teacher : IdentityBase
{
    private readonly HashSet<Subject> _subjects = new();

    public string FullName { get; init; }
    public IReadOnlyCollection<Subject> Subjects => _subjects;

    public Guid? EducationalClassId { get; set; }
    public virtual EducationalClass? EducationalClass { get; private set; }

    protected Teacher() { }

    public Teacher(List<Subject> subjects, string fullName)
    {
        (FullName) = (fullName);
        AddTeachingSubjects(subjects);
    }

    public Teacher(Subject subject, string fullName)
    {
        (FullName) = (fullName);
        _subjects.Add(subject);
    }

    public void AddTeachingSubject(Subject subject)
    {
        if (
            subject != null
            && !_subjects.Contains(subject)
            )
        {
            _subjects.Add(subject);
            return;
        }

        throw new ArgumentException(nameof(this.AddTeachingSubject), nameof(subject));
    }

    private void AddTeachingSubjects(List<Subject> subjects)
    {
        if (
            subjects != null
            && subjects.Any()
            && !subjects.HasDuplications()
            && !_subjects.Any(x => subjects.Contains(x))
            )
        {
            foreach (var subject in subjects)
            {
                _subjects.Add(subject);
            }

            return;
        }

        throw new ArgumentException(nameof(this.AddTeachingSubjects), nameof(subjects));
    }
}

