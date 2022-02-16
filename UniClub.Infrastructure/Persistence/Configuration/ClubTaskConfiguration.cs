using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniClub.Domain.Entities;

namespace UniClub.Infrastructure.Persistence.Configuration
{
    public class ClubTaskConfiguration : IEntityTypeConfiguration<ClubTask>
    {
        public void Configure(EntityTypeBuilder<ClubTask> entity)
        {
            entity.ToTable("Task");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasIndex(e => e.EventId, "IX_Task_EventId");


            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.EndDate).HasColumnType("datetime");


            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.Property(e => e.TaskName)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.Event)
                .WithMany(p => p.Tasks)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_Event");
        }
    }
}
