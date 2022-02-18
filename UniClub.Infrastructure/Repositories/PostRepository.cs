using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        protected override IQueryable<Post> Search(IQueryable<Post> query, string searchValue)
            => query.Where(e => e.Id.ToString().Equals(searchValue)
                            || e.PersonId.ToString().Equals(searchValue)
                            || e.Status.ToString().Equals(searchValue)
                            || EF.Functions.Collate(e.Content, "SQL_Latin1_General_CP1_CI_AI").Contains(searchValue)
                            || e.EventId.ToString().Equals(searchValue));
    }
}
