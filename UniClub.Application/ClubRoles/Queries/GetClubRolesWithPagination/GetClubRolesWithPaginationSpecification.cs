using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Common;
using UniClub.Domain.Entities;

namespace UniClub.Application.ClubRoles.Queries.GetClubRolesWithPagination
{
    public class GetClubRolesWithPaginationSpecification : BaseSpecification<ClubRole>
    {
        public GetClubRolesWithPaginationSpecification(GetClubRolesWithPaginationQuery query) : base()
        {
            SetFilterCondition(e => e.Id.ToString().Equals(query.SearchValue)
                                        || EF.Functions.Collate(e.Role, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                                        || e.ReportToRoleId.ToString().Equals(query.SearchValue));

            ApplyOrderBy(query.OrderBy);
            ApplyOrder(query.IsAscending);

            ApplyPagination(query.PageNumber, query.PageSize);
        }
    }
}
