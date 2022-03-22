using MediatR;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Enums.Properties;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetWithPagination
{
    public class GetStudentsWithPaginationDto : RequestPaginationQuery<PersonProperties?>, IRequest<PaginatedList<UserDto>>
    {
        private int _uniId;

        public override PersonProperties? OrderBy { get; set; }
        public int UniId { get => _uniId; }
        public void SetUniId(int uniId) => _uniId = uniId;
    }
}
