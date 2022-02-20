using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Common;
using UniClub.Domain.Entities;

namespace UniClub.Application.Departments.Queries.GetDepartmentsWithPagination
{
    public class GetDepartmentsWithPaginationSpecification : BaseSpecification<Department>
    {
        public GetDepartmentsWithPaginationSpecification(GetDepartmentsWithPaginationQuery query) : base()
        {
            SetFilterCondition(e => e.Id.ToString().Equals(query.SearchValue)
                                    || e.UniId.ToString().Equals(query.SearchValue)
                                    || EF.Functions.Collate(e.DepName, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                                    || EF.Functions.Collate(e.ShortName, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue));

            ApplyOrderBy(query.OrderBy);
            ApplyOrder(query.IsAscending);

            ApplyPagination(query.PageNumber, query.PageSize);
        }
    }
}
