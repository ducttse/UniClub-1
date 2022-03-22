using MediatR;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Enums;
using UniClub.Domain.Common.Enums.Properties;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetWithPagination
{
    public class GetUsersWithPaginationDto : RequestPaginationQuery<PersonProperties?>, IRequest<PaginatedList<UserDto>>
    {
        public override PersonProperties? OrderBy { get; set; }
        public Role Role { get; set; }
    }
}
