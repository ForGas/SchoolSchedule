using Microsoft.AspNetCore.Mvc;
using SchoolSchedule.Application.Features.EducationalClass.Commands.CreateStudent;
using SchoolSchedule.Application.Features.EducationalClass.Queries;
using SchoolSchedule.Application.Features.EducationalClass.Queries.GetStudentById;
using SchoolSchedule.Application.Features.EducationalClass.Queries.GetStudents;

namespace SchoolSchedule.Api.Controllers;

[Route("api/[controller]/[action]")]
public class EducationalClassController : ApiControllerBase
{
    [HttpPost]
    public async Task<Guid> Create([FromBody] CreateStudentCommand command)
    => await Mediator.Send(command);

    [HttpGet]
    [Route("{id}")]
    public async Task<StudentDto> GetById([FromRoute] Guid id)
        => await Mediator.Send(new GetStudentByIdQuery(id));

    [HttpGet]
    public async Task<List<StudentDto>> GetAll([FromQuery] GetStudentsQuery query)
        => await Mediator.Send(query);
}
