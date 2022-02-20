using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Common;
using UniClub.Domain.Entities;

namespace UniClub.Application.Universities.Queries.GetUniversitiesWithPagination
{
    public class GetUniversitiesWithPaginationSpecification : BaseSpecification<University>
    {
        public GetUniversitiesWithPaginationSpecification(GetUniversitiesWithPaginationQuery query)
        {
            SetFilterCondition(e => e.Id.ToString().Equals(query.SearchValue)
                                        || EF.Functions.Collate(e.ShortName, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                                        || e.Website.Contains(query.SearchValue)
                                        || e.UniPhone.Contains(query.SearchValue)
                                        || EF.Functions.Collate(e.UniName, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                                        || EF.Functions.Collate(e.UniAddress, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                                        || EF.Functions.Collate(e.Slogan, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                                        || e.EstablishedDate.ToString().Equals(query.SearchValue));

            ApplyOrderBy(query.OrderBy);
            ApplyOrder(query.IsAscending);

            ApplyPagination(query.PageNumber, query.PageSize);
        }
    }
}
