﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.GetById;
using UniClub.Specifications;

namespace UniClub.Queries.GetById.Specifications
{
    public class GetUniversityByIdQuerySpecification : BaseSpecification<University>
    {
        public GetUniversityByIdQuerySpecification(GetUniversityByIdDto dto)
        {
            SetFilterCondition(e => !e.IsDeleted);

            SetFilterCondition(e => e.Id == dto.Id);
        }
    }
}
