using MediatR;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Enums.Properties;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetWithPagination
{
    public class GetClubsWithPaginationDto : RequestPaginationQuery<ClubProperties?>, IRequest<PaginatedList<ClubDto>>
    {
        private int _uniId;

        public int UniId { get => _uniId; }
        public void SetUniId(int uniId) => _uniId = uniId;
        public override ClubProperties? OrderBy { get; set; }
    }
}
