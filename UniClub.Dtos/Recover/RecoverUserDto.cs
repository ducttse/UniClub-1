using MediatR;
using System.ComponentModel.DataAnnotations;

namespace UniClub.Dtos.Recover
{
    public class RecoverUserDto : IRequest<int>
    {
        [Required]
        public string Id { get; set; }
    }
}
