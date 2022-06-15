﻿using System.Linq.Expressions;

namespace SchoolSchedule.Application.Contracts;

public interface IQueryBaseRepository<T>
{
    IQueryable<T> Get(Expression<Func<T, bool>> selector);
    IQueryable<T> Get();
    IQueryable<T> GetAll();
}