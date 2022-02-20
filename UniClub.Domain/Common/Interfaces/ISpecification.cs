﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace UniClub.Domain.Common.Interfaces
{
    public interface ISpecification<T>
    {
        bool SoftDeleteFilter { get; }
        //Expression<Func<T, object>> Select { get; }
        List<Expression<Func<T, bool>>> FilterCondition { get; }
        string? OrderBy { get; }
        bool IsAscending { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> GroupBy { get; }
        bool IsPagination { get; }
        int Skip { get; }
        int Take { get; }

    }
}
