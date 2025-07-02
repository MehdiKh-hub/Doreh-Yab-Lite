using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastracture.Persistence.Configurations
{
    public class SubjectConfig : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.Rank)
                .IsRequired();

            builder.Property(s => s.Description)
                .HasMaxLength(1000);

            builder.Metadata.FindNavigation(nameof(Subject.Courses))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
    
}
