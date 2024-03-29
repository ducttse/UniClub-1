﻿using System;
using UniClub.Domain.Common.Enums;

namespace UniClub.Dtos.Response
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PersonId { get; set; }
        public string Content { get; set; }
        public PostStatus Status { get; set; }
        public string ShortDescription { get; set; }
        public int? EventId { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsDeleted { get; set; }

    }
}
