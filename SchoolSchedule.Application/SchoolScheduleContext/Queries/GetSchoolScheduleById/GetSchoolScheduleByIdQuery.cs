﻿using MediatR;

namespace SchoolSchedule.Application.SchoolScheduleContext.Queries.GetSchoolScheduleById;

public record class GetSchoolScheduleByIdQuery(Guid Id) : IRequest<SchoolScheduleDto>;

public class GetSchoolScheduleByIdQueryHandler : IRequestHandler<GetSchoolScheduleByIdQuery, SchoolScheduleDto>
{
    public Task<SchoolScheduleDto> Handle(GetSchoolScheduleByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
