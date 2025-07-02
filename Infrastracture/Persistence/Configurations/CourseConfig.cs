using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastracture.Persistence.Configurations
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Description)
                .HasMaxLength(1000);

            builder.Property(c => c.DurationInHours)
                .IsRequired();

            builder.Property(c => c.Rank)
                .IsRequired();

          

            builder.HasOne(c => c.Subject)
                .WithMany(s => s.Courses)
                .HasForeignKey(c => c.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Source)
                .WithMany(s => s.Courses)
                .HasForeignKey(c => c.SourceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Metadata.FindNavigation(nameof(Course.StudentCourses))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
