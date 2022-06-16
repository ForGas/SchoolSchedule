using MediatR;
using SchoolSchedule.Application.Contracts;
using SchoolSchedule.Domain;

namespace SchoolSchedule.Application.StudentContext.Commands.CreateStudent;

public class CreateStudentCommand : IRequest<Guid>
{
    public string FullName { get; set; } = null!;
    public DateOnly BirthYear { get; set; }
}


public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Guid>
{
    private readonly ICommandStudentRepository _studentRepository;

    public CreateStudentCommandHandler(ICommandStudentRepository studentRepository)
        => (_studentRepository) = (studentRepository);

    public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = new Student(request.FullName, request.BirthYear);
        var result = await _studentRepository.EnrollmentInSchoolAsync(student);

        return result;
    }
}