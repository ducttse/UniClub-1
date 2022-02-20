﻿using Microsoft.EntityFrameworkCore;
using UniClub.Application.Common;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Infrastructure.Repositories
{
    public class PostRepository : CRUDRepository<Post, int>, IPostRepository
    {
        public PostRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.Posts;
        }

        protected override DbSet<Post> DbSet { get; }

    }
}
