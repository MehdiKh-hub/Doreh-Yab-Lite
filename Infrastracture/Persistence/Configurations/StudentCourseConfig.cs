using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastracture.Persistence.Configurations
{
    public class StudentCourseConfig : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.ToTable("StudentCourses");

            builder.HasKey(sc => new { sc.StudentId, sc.CourseId }); // کلید ترکیبی

            builder.Property(sc => sc.EnrollmentDate)
                .IsRequired();

            builder.Property(sc => sc.IsCompleted)
                .IsRequired();

            builder.HasOne(sc => sc.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        
    }

}
