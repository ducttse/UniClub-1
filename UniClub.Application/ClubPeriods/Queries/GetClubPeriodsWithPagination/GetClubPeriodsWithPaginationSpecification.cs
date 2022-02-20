using UniClub.Domain.Common;
using UniClub.Domain.Entities;

namespace UniClub.Application.ClubPeriods.Queries.GetClubPeriodsWithPagination
{
    public class GetClubPeriodsWithPaginationSpecification : BaseSpecification<ClubPeriod>
    {
        public GetClubPeriodsWithPaginationSpecification(GetClubPeriodsWithPaginationQuery query) : base()
        {
            if (!string.IsNullOrWhiteSpace(query.SearchValue))
            {
                SetFilterCondition(e => e.Id.ToString().Equals(query.SearchValue)
                                        || e.Status.ToString().Equals(query.SearchValue));
            }

            if (query.StartDate != null && query.EndDate != null)
            {
                SetFilterCondition(e => query.StartDate <= e.StartDate && e.EndDate <= query.EndDate);
            }
            else if (query.StartDate != null)
            {
                SetFilterCondition(e => query.StartDate <= e.StartDate);
            }
            else if (query.EndDate != null)
            {
                SetFilterCondition(e => e.EndDate <= query.EndDate);
            }

            ApplyOrderBy(query.OrderBy);
            ApplyOrder(query.IsAscending);

            ApplyPagination(query.PageNumber, query.PageSize);
        }
    }
}
