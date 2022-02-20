using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Common;
using UniClub.Domain.Entities;

namespace UniClub.Application.Clubs.Queries.GetClubsWithPagination
{
    public class GetClubsWithPaginationSpecification : BaseSpecification<Club>
    {
        public GetClubsWithPaginationSpecification(GetClubsWithPaginationQuery query) : base()
        {
            if (!string.IsNullOrEmpty(query.SearchValue))
            {
                SetFilterCondition(e => (e.UniId.Equals(query.UniId)) &&
                                    (e.Id.ToString().Equals(query.SearchValue)
                                    || EF.Functions.Collate(e.ClubName, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                                    || EF.Functions.Collate(e.ShortName, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                                    || EF.Functions.Collate(e.Description, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                                    || EF.Functions.Collate(e.ShortDescription, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                                    || e.EstablishedDate.ToString().Contains(query.SearchValue)
                                    || EF.Functions.Collate(e.Slogan, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)));
            }
            else
            {
                SetFilterCondition(e => e.UniId.Equals(query.UniId));
            }

            ApplyOrderBy(query.OrderBy);
            ApplyOrder(query.IsAscending);

            ApplyPagination(query.PageNumber, query.PageSize);
        }
    }
}
