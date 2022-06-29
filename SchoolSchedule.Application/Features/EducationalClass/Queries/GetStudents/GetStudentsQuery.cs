using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolSchedule.Infrastructure.Repository.Shared.Student.Abstractions;

namespace SchoolSchedule.Application.Features.EducationalClass.Queries.GetStudents;

public record class GetStudentsQuery() : IRequest<List<StudentDto>>;


public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<StudentDto>>
{
    private readonly IQueryStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public GetStudentsQueryHandler(IQueryStudentRepository studentRepository, IMapper mapper)
        => (_studentRepository, _mapper) = (studentRepository, mapper);

    public async Task<List<StudentDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await _studentRepository.GetAll().ToListAsync();

        return _mapper.Map<List<StudentDto>>(students);
    }
}


