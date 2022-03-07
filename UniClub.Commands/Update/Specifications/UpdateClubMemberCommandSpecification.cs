﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.Update;
using UniClub.Specifications;

namespace UniClub.Commands.Update.Specifications
{
    public class UpdateClubMemberCommandSpecification : BaseSpecification<MemberRole>
    {
        public UpdateClubMemberCommandSpecification(UpdateClubMemberDto dto)
        {
            SetFilterCondition(e => !e.IsDeleted);

            SetFilterCondition(e => e.ClubPeriodId == dto.GetClubPeriodId() && e.MemberId.Equals(dto.MemberId));
        }
    }
}
