using MediatR;

namespace SchoolSchedule.Application.StudentContext.Queries.GetStudents;

public record class GetStudentsQuery() : IRequest<List<StudentDto>>;


public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<StudentDto>>
{
    public GetStudentsQueryHandler()
    {

    }

    public Task<List<StudentDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}


