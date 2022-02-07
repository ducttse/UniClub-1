using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniClub.Domain.Entities;

namespace UniClub.Infrastructure.Persistence.Configuration
{
    public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> entity)
        {
            entity.HasKey(e => new { e.Id, e.EventId });

            entity.ToTable("Participant");

            entity.Property(e => e.CheckInDate).HasColumnType("datetime");

            entity.Property(e => e.CheckoutDate).HasColumnType("datetime");

            entity.Property(e => e.JoinDate).HasColumnType("datetime");

            entity.HasOne(d => d.Event)
                .WithMany(p => p.Participants)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Participant_Event");

            entity.HasOne(d => d.Person)
                .WithMany(p => p.Participants)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Participant_Person");
        }
    }
}
