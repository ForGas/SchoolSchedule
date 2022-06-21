﻿using SchoolSchedule.Domain.SeedWork;
using System.Linq.Expressions;

namespace SchoolSchedule.Application.Contracts;

public interface IQueryBaseRepository<T>
    where T : IdentityBase
{
    IQueryable<T> Get(Expression<Func<T, bool>> selector);
    Task<T> GetByIdAsync(Guid Id);
    IQueryable<T> GetAll();
}
