using Microsoft.EntityFrameworkCore;
using UniClub.Application.Common;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Infrastructure.Repository
{
    public class PostImageRepository : CRUDRepository<PostImage, int>, IPostImageRepository
    {
        public PostImageRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.PostImages;
        }

        protected override DbSet<PostImage> DbSet { get; }
    }
}
