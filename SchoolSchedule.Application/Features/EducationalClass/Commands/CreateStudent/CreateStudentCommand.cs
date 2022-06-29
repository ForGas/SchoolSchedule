using MediatR;
using SchoolSchedule.Application.Contracts;
using SchoolSchedule.Domain.EducationalClassAggregate;
using SchoolSchedule.Infrastructure.Repository.Shared.Student.Abstractions;

namespace SchoolSchedule.Application.Features.EducationalClass.Commands.CreateStudent;

public class CreateStudentCommand : IAggregateTransactionCommand<Guid>
{
    public string FullName { get; set; } = null!;
    public DateTime BirthYear { get; set; }
}


public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Guid>
{
    private readonly ICommandStudentRepository _studentRepository;

    public CreateStudentCommandHandler(ICommandStudentRepository studentRepository)
        => (_studentRepository) = (studentRepository);

    public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = new Student(Guid.NewGuid(), request.FullName, DateOnly.FromDateTime(request.BirthYear), null); ; ;
        var result = await _studentRepository.EnrollmentInSchoolAsync(student);

        _ = _studentRepository.SaveChangesAsync(cancellationToken);

        return result;
    }
}