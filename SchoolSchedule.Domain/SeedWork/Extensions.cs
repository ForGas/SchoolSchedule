using SchoolSchedule.Domain.LessonAggregate;

namespace SchoolSchedule.Domain.SeedWork;

public static class Extensions
{
    public static bool HasDuplications(this List<Subject> sender) =>
        sender.GroupBy(value => value).Any(@group => @group.Count() > 1);
}
