using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniClub.Domain.Entities;

namespace UniClub.Infrastructure.Persistence.Configuration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> entity)
        {
            entity.ToTable("Event");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.EndDate).HasColumnType("datetime");

            entity.Property(e => e.EventName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.ImageUrl).HasMaxLength(256);

            entity.Property(e => e.Location)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.StartDate).HasColumnType("datetime");
        }
    }
}
