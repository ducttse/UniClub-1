﻿using UniClub.Domain.Entities;
using UniClub.Dtos.GetById;
using UniClub.Specifications;

namespace UniClub.Queries.GetById.Specifications
{
    public class GetDepartmentByIdQuerySpecification : BaseSpecification<Department>
    {
        public GetDepartmentByIdQuerySpecification(GetDepartmentByIdDto dto)
        {
            SetFilterCondition(e => !e.IsDeleted);

            SetFilterCondition(e => e.Id == dto.Id && e.UniId == dto.UniId);
        }
    }
}
