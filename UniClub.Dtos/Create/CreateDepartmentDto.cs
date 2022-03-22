using MediatR;

namespace UniClub.Dtos.Create
{
    public class CreateDepartmentDto : IRequest<int>
    {
        private int _uniId;

        public int UniId { get => _uniId; }
        public void SetUniId(int uniId) => _uniId = uniId;
        public string DepName { get; set; }
        public string ShortName { get; set; }
    }
}
