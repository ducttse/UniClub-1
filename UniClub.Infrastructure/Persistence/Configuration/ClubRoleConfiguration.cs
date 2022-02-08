using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniClub.Domain.Entities;

namespace UniClub.Infrastructure.Persistence.Configuration
{
    public class ClubRoleConfiguration : IEntityTypeConfiguration<ClubRole>
    {
        public void Configure(EntityTypeBuilder<ClubRole> entity)
        {
            entity.ToTable("ClubRole");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasIndex(e => e.ClubId, "IX_ClubRole_ClubId");

            entity.HasIndex(e => e.ClubPeriodId, "IX_ClubRole_ClubPeriodId");

            entity.HasIndex(e => e.ReportToRoleId, "IX_ClubRole_ReportToRoleId");

            entity.Property(e => e.CreatedBy).HasMaxLength(300);

            entity.Property(e => e.LastModifiedBy).HasMaxLength(300);

            entity.Property(e => e.Role)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Club)
                .WithMany(p => p.ClubRoles)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClubRole_Club");

            entity.HasOne(d => d.ClubPeriod)
                .WithMany(p => p.ClubRoles)
                .HasForeignKey(d => d.ClubPeriodId)
                .HasConstraintName("FK_ClubRole_ClubPeriod");

            entity.HasOne(d => d.ReportToRole)
                .WithMany(p => p.InverseReportToRole)
                .HasForeignKey(d => d.ReportToRoleId)
                .HasConstraintName("FK_ClubRole_ClubRole");
        }
    }
}
