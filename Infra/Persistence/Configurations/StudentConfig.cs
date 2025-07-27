using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Persistence.Configurations
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.FullName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.Age)
                .IsRequired();

            builder.Property(s => s.Level)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.CreatedAt)
                .IsRequired();

            builder.Metadata.FindNavigation(nameof(Student.Enrollments))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
