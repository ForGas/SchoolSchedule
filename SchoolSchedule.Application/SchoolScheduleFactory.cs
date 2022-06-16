using SchoolSchedule.Application.SchoolScheduleContext.Queries.GetSchoolScheduleById;
using SchoolSchedule.Domain;

namespace SchoolSchedule.Application;

public static class SchoolDayScheduleFactory
{
    public static SchoolDaySchedule CreateSchoolSchedule(SchoolScheduleDto schoolScheduleDto)
    {
        var schoolSchedule = new SchoolDaySchedule();



        return schoolSchedule;
    }
}
