using Microsoft.EntityFrameworkCore;
using System.Linq;
using UniClub.Application.Common;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Infrastructure.Repositories
{
    public class PostImageRepository : CRUDRepository<PostImage, int>, IPostImageRepository
    {
        public PostImageRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.PostImages;
        }

        protected override DbSet<PostImage> DbSet { get; }

        protected override IQueryable<PostImage> Search(IQueryable<PostImage> query, string searchValue)
            => query.Where(e => e.Id.ToString().Equals(searchValue)
                                        || e.PostId.ToString().Equals(searchValue));
    }
}
