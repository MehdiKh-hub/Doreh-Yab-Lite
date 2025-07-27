using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Persistence.Configurations
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {

            builder.ToTable("Teachers");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.FullName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.Rank)
                .IsRequired();

            builder.Property(t => t.Bio)
                .HasMaxLength(1000);

            builder.Property(t => t.Email)
                .HasMaxLength(200);

            builder.Metadata.FindNavigation(nameof(Teacher.Courses))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
