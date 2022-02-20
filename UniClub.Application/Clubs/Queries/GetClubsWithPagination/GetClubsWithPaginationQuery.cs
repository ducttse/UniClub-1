using MediatR;
using System.ComponentModel.DataAnnotations;
using UniClub.Application.Clubs.Dtos;
using UniClub.Application.Common;
using UniClub.Domain.Common;

namespace UniClub.Application.Clubs.Queries.GetClubsWithPagination
{
    public class GetClubsWithPaginationQuery : RequestPaginationQuery, IRequest<PaginatedList<ClubDto>>
    {
        [Required]
        public int UniId { get; set; }
    }
}
