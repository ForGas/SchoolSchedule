using SchoolSchedule.Domain.Common;
using SchoolSchedule.Domain.LessonAggregate;
using SchoolSchedule.Domain.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSchedule.Domain.SchoolDayScheduleAggregate;

public class SchoolDaySchedule : AggregateRoot
{
    private bool _isActive;
    private readonly List<Lesson> _lessons = new();

    protected SchoolDaySchedule() { }
    public SchoolDaySchedule(DateOnly day)
        => (Day, _isActive) = (day, true);


    [NotMapped]
    public override AggregateType RootType => AggregateType.SchoolDaySchedule;
    public DateOnly Day { get; init; }
    public bool IsActive { get => _isActive; protected set => _isActive = value; }
    public virtual IReadOnlyCollection<Lesson> Lessons => _lessons;

    public void SetActiveSchoolDaySchedule(bool active) => _isActive = active;

    private void AddLessonForDaySchedule(Lesson lesson)
    {
        if (
            lesson != null
            && _lessons.All(x => x.Id != x.Id)
            && IsTimeCorrect(lesson)
            )
        {
            _lessons.Add(lesson);
            lesson.SetSchoolDaySchedule(this);
            return;
        }

        throw new ArgumentException(nameof(this.AddLessonForDaySchedule), nameof(lesson));
    }

    private bool IsTimeCorrect(Lesson lesson)
        => !_lessons.Any(x =>
            (x.EndTime >= lesson.EndTime && lesson.EndTime <= x.StartTime)
            || (x.EndTime >= lesson.StartTime && lesson.StartTime <= x.StartTime));
    
}

