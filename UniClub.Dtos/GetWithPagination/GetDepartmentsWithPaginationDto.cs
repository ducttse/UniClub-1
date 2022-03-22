using MediatR;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Enums.Properties;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetWithPagination
{
    public class GetDepartmentsWithPaginationDto : RequestPaginationQuery<DepartmentProperties?>, IRequest<PaginatedList<DepartmentDto>>
    {
        private int _uniId;

        public int UniId { get => _uniId; }
        public void SetUniId(int uniId) => _uniId = uniId;
        public override DepartmentProperties? OrderBy { get; set; }
    }
}
