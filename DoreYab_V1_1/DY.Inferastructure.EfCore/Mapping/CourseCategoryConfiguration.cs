using DY.Domain.CourseCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DY.Inferastructure.EfCore.Mapping
{
    public class CourseCategoryConfiguration : IEntityTypeConfiguration<CourseCategory>
    {
        public void Configure(EntityTypeBuilder<CourseCategory> builder)
        {
            // Table Name
            builder.ToTable("CourseCategories");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(true);

            builder.Property(x => x.ShortDescription)
                .HasMaxLength(1000)
                .IsUnicode(true);

            builder.Property(x => x.CourseCount)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.CreationDate)
                .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasMany(x => x.Courses)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // دسته‌بندی نباید با پاک شدن، دوره‌هاش هم پاک بشن

            // Indexes
            builder.HasIndex(x => x.Title).IsUnique();
        }
    }
}
