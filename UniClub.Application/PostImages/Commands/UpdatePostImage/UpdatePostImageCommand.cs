using MediatR;
using System.ComponentModel.DataAnnotations;

namespace UniClub.Application.PostImages.Commands.UpdatePostImage
{
    public class UpdatePostImageCommand : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
        public int PostId { get; set; }
        public string ImageUrl { get; set; }
    }
}
