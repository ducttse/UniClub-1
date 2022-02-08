﻿using MediatR;
using System.ComponentModel.DataAnnotations;
using UniClub.Domain.Common.Enums;

namespace UniClub.Application.Posts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
        public string PersonId { get; set; }
        public string Content { get; set; }
        public PostStatus Status { get; set; }
        public string ShortDescription { get; set; }
        public int? EventId { get; set; }
    }
}
