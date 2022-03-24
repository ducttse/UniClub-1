using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using UniClub.Domain.Common.Enums;

namespace UniClub.Dtos.Update
{
    public class UpdatePostDto : IRequest<int>
    {
        public int Id { get; set; }
        public string PersonId { get; set; }
        public string Content { get; set; }
        public PostStatus Status { get; set; }
        public IList<IFormFile> Images { get; set; }
        public string ShortDescription { get; set; }
        public int? EventId { get; set; }
        public string Title { get; set; }
    }
}
