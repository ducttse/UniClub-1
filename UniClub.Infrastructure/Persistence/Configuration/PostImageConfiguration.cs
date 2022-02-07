using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniClub.Domain.Entities;

namespace UniClub.Infrastructure.Persistence.Configuration
{
    public class PostImageConfiguration : IEntityTypeConfiguration<PostImage>
    {
        public void Configure(EntityTypeBuilder<PostImage> entity)
        {
            entity.ToTable("PostImage");

            entity.HasKey(e => e.ImageId);

            entity.Property(e => e.ImageId).ValueGeneratedOnAdd();

            entity.Property(e => e.ImageUrl)
                .IsRequired()
                .HasMaxLength(256);

            entity.HasOne(d => d.Post)
                .WithMany(p => p.PostImages)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PostImage_Post");
        }
    }
}
