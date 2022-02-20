using UniClub.Domain.Common;
using UniClub.Domain.Entities;

namespace UniClub.Application.Students.Queries.GetStudentsWithPagination
{
    public class GetStudentsWithPaginationSpecification : BaseSpecification<Person>
    {
        public GetStudentsWithPaginationSpecification(GetStudentsWithPaginationQuery query)
        {
            ApplyOrderBy(query.OrderBy);
            ApplyOrder(query.IsAscending);

            ApplyPagination(query.PageNumber, query.PageSize);
        }
    }
}
