using MediatR;

namespace SchoolSchedule.Application.Features.SchoolSchedule.Commands.CreateSchoolSchedule;

public class CreateSchoolScheduleCommand : IRequest<Guid>
{

}

public class CreateSchoolScheduleCommandHandler : IRequestHandler<CreateSchoolScheduleCommand, Guid>
{
    public CreateSchoolScheduleCommandHandler()
    {

    }

    public Task<Guid> Handle(CreateSchoolScheduleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
