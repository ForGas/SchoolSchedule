using Microsoft.AspNetCore.Mvc;
using SchoolSchedule.Application.StudentContext.Commands.CreateStudent;
using SchoolSchedule.Application.StudentContext.Queries;
using SchoolSchedule.Application.StudentContext.Queries.GetStudentById;
using SchoolSchedule.Application.StudentContext.Queries.GetStudents;

namespace SchoolSchedule.Api.Controllers;

[Route("api/[controller]/[action]")]
public class StudentController : ApiControllerBase
{
    [HttpPost]
    public async Task<Guid> Create([FromForm] CreateStudentCommand command)
        => await Mediator.Send(command);

    [HttpGet]
    [Route("{id}")]
    public async Task<StudentDto> GetById([FromRoute] Guid id)
        => await Mediator.Send(new GetStudentByIdQuery(id));

    [HttpGet]
    public async Task<List<StudentDto>> GetAll([FromQuery] GetStudentsQuery query)
        => await Mediator.Send(query);
}
