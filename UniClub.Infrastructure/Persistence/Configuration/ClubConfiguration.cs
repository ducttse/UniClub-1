using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniClub.Domain.Entities;

namespace UniClub.Infrastructure.Persistence.Configuration
{
    public class ClubConfiguration : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> entity)
        {
            entity.ToTable("Club");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.AvatarUrl)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.ClubName)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.CreatedDate).HasColumnType("date");

            entity.Property(e => e.Description).HasMaxLength(400);

            entity.Property(e => e.ShortDescription)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.ShortName)
                .IsRequired()
                .HasMaxLength(10);

            entity.Property(e => e.Slogan).HasMaxLength(256);

            entity.HasOne(d => d.Uni)
                .WithMany(p => p.Clubs)
                .HasForeignKey(d => d.UniId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Club_University");
        }
    }
}
