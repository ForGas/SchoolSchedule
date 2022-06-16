using AutoMapper;
using MediatR;
using SchoolSchedule.Application.Contracts;

namespace SchoolSchedule.Application.StudentContext.Queries.GetStudentById;

public record class GetStudentByIdQuery(Guid Id) : IRequest<StudentDto>;

public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
{
    private readonly IQueryStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public GetStudentByIdQueryHandler(IQueryStudentRepository studentRepository, IMapper mapper)
        => (_studentRepository, _mapper) = (studentRepository, mapper);

    public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _studentRepository.GetByIdAsync(request.Id);
        return _mapper.Map<StudentDto>(entity);
    }
}