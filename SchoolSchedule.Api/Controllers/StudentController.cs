using Microsoft.AspNetCore.Mvc;
using SchoolSchedule.Application.StudentBoundary.Commands.CreateStudent;
using SchoolSchedule.Application.StudentBoundary.Queries;
using SchoolSchedule.Application.StudentBoundary.Queries.GetStudentById;
using SchoolSchedule.Application.StudentBoundary.Queries.GetStudents;

namespace SchoolSchedule.Api.Controllers;

[Route("api/[controller]/[action]")]
public class StudentController : ApiControllerBase
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
