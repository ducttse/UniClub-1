using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniClub.Domain.Entities;

namespace UniClub.Infrastructure.Persistence.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Department");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.DepName)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.ShortName)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength(true);

            entity.HasOne(d => d.Uni)
                .WithMany(p => p.Departments)
                .HasForeignKey(d => d.UniId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Department_University");
        }
    }
}
