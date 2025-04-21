using DY.Domain.CourseAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DY.Inferastructure.EfCore.Mapping
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable(nameof(Course));
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).IsRequired().HasMaxLength(150);
            builder.Property(c => c.SiteSource).IsRequired();
            builder.Property(c => c.Desctiption);
            builder.Property(c => c.ImageUrl);
            builder.Property(c => c.IsFinished).IsRequired();
            builder.Property(c => c.Slug).IsRequired();
            builder.Property(c => c.Price);
            builder.Property(c => c.MetaTitle);
            builder.Property(c => c.MetaDescription);
            builder.Property(c => c.MetaKeyword);

            builder.HasOne(c => c.Category).WithMany(b => b.Courses).HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
