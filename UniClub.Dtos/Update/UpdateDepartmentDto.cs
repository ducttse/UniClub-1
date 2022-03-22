using MediatR;
using System.ComponentModel.DataAnnotations;

namespace UniClub.Dtos.Update
{
    public class UpdateDepartmentDto : IRequest<int>
    {
        private int _uniId;

        [Required]
        public int Id { get; set; }
        public int UniId { get => _uniId; }
        public void SetUniId(int uniId) => _uniId = uniId;
        public string DepName { get; set; }
        public string ShortName { get; set; }
    }
}
