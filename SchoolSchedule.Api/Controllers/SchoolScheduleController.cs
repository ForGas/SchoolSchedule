using Microsoft.AspNetCore.Mvc;
using SchoolSchedule.Application.SchoolScheduleContext.Queries.GetSchoolScheduleById;

namespace SchoolSchedule.Api.Controllers;

[Route("api/[controller]/[action]")]
public class SchoolScheduleController : ApiControllerBase
{
    [HttpGet]
    public async Task<SchoolScheduleDto> GetById([FromQuery] GetSchoolScheduleByIdQuery query)
        => await Mediator.Send(query);
}
