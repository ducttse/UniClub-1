﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniClub.Domain.Entities;

namespace UniClub.Infrastructure.Persistence.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> entity)
        {
            entity.ToTable("Department");

            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();

            entity.HasIndex(e => e.UniId, "IX_Department_UniId");

            entity.Property(e => e.DepName)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.ShortName)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength(true);

            entity.HasOne(d => d.University)
                .WithMany(p => p.Departments)
                .HasForeignKey(d => d.UniId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Department_University");
        }
    }
}
