using MediatR;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Enums.Properties;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetWithPagination
{
    public class GetStudentsWithPaginationDto : RequestPaginationQuery<PersonProperties?>, IRequest<PaginatedList<StudentDto>>
    {
        public override PersonProperties? OrderBy { get; set; }
    }
}
