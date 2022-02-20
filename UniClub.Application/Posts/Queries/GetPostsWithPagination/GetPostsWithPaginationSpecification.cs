using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Common;
using UniClub.Domain.Entities;

namespace UniClub.Application.Posts.Queries.GetPostsWithPagination
{
    public class GetPostsWithPaginationSpecification : BaseSpecification<Post>
    {
        public GetPostsWithPaginationSpecification(GetPostsWithPaginationQuery query) : base()
        {
            SetFilterCondition(e => e.Id.ToString().Equals(query.SearchValue)
                            || e.PersonId.ToString().Equals(query.SearchValue)
                            || e.Status.ToString().Equals(query.SearchValue)
                            || EF.Functions.Collate(e.Content, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                            || e.EventId.ToString().Equals(query.SearchValue));

            ApplyOrderBy(query.OrderBy);
            ApplyOrder(query.IsAscending);

            ApplyPagination(query.PageNumber, query.PageSize);
        }
    }
}
