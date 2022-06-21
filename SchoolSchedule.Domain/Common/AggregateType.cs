using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SchoolSchedule.Domain.Common;

[JsonConverter(typeof(StringEnumConverter))]
public enum AggregateType
{
    NoDefinition = 0,
    EducationalClass = 1,
    Lesson = 2,
    Teacher = 3,
    SchoolDaySchedule = 4,
}
