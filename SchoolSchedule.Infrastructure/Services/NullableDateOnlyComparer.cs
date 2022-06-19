using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SchoolSchedule.Infrastructure.Services;

public class NullableDateOnlyComparer : ValueComparer<DateOnly?>
{
    public NullableDateOnlyComparer()
        : base(
        (d1, d2) => d1 == d2 && d1.GetValueOrDefault().DayNumber == d2.GetValueOrDefault().DayNumber,
        d => d.GetHashCode()
        )
    { }
}