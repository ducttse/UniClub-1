using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Common;
using UniClub.Domain.Entities;

namespace UniClub.Application.ClubTasks.Queries.GetClubTasksWithPagination
{
    public class GetClubTaskWithPaginationSpecification : BaseSpecification<ClubTask>
    {
        public GetClubTaskWithPaginationSpecification(GetClubTasksWithPaginationQuery query) : base()
        {
            SetFilterCondition(e => e.Id.ToString().Equals(query.SearchValue)
                                    || e.EventId.ToString().Equals(query.SearchValue)
                                    || e.Status.ToString().Equals(query.SearchValue)
                                    || EF.Functions.Collate(e.TaskName, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                                    || EF.Functions.Collate(e.Description, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue));

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
