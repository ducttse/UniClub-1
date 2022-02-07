using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniClub.Domain.Entities;

namespace UniClub.Infrastructure.Persistence.Configuration
{
    public class UniversityConfiguration : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("University");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.FoundDate).HasColumnType("date");

            entity.Property(e => e.LogoUrl)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.ShortName)
                .IsRequired()
                .HasMaxLength(10);

            entity.Property(e => e.Slogan).HasMaxLength(256);

            entity.Property(e => e.UniAddress)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.UniName)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.UniPhone).HasMaxLength(12);

            entity.Property(e => e.Website).HasMaxLength(256);
        }
    }
}

