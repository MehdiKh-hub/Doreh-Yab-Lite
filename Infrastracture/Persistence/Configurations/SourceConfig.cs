using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastracture.Persistence.Configurations
{
    public class SourceConfig : IEntityTypeConfiguration<Source>
    {
        public void Configure(EntityTypeBuilder<Source> builder)
        {
            builder.ToTable("Sources");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.Rank)
                .IsRequired();

            builder.Property(s => s.WebsiteUrl)
                .HasMaxLength(500);

            builder.Metadata.FindNavigation(nameof(Source.Courses))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
