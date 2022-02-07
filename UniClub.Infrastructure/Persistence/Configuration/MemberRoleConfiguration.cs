﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniClub.Domain.Entities;

namespace UniClub.Infrastructure.Persistence.Configuration
{
    public class MemberRoleConfiguration : IEntityTypeConfiguration<MemberRole>
    {
        public void Configure(EntityTypeBuilder<MemberRole> entity)
        {
            entity.HasKey(e => new { e.MemberId, e.ClubRoleId });

            entity.ToTable("MemberRole");

            entity.Property(e => e.EndDate).HasColumnType("datetime");

            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.ClubRole)
                .WithMany(p => p.MemberRoles)
                .HasForeignKey(d => d.ClubRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberRole_ClubRole");

            entity.HasOne(d => d.Member)
                .WithMany(p => p.MemberRoles)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberRole_Member");
        }
    }
}
