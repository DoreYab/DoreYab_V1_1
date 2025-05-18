using DY.Domain.CourseAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FluentValidation;
namespace DY.Inferastructure.EfCore.Mapping
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // Table Name
            builder.ToTable("Courses");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(true);

            builder.Property(x => x.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired(false);

            builder.Property(x => x.Description)
                .HasMaxLength(3000)
                .IsUnicode(true);

            builder.Property(x => x.CourseUrl)
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(x => x.SiteSource)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(false);

            builder.Property(x => x.ImageUrl)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(x => x.IsFree)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsRequired();

            builder.Property(x => x.IsFinished)
                .IsRequired();

            builder.Property(x => x.MetaTitle)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(true);

            builder.Property(x => x.MetaDescription)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(true);

            builder.Property(x => x.MetaKeyword)
                .IsRequired()
                .HasMaxLength(600)
                .IsUnicode(true);

            builder.Property(x => x.CreationDate)
                .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // برای جلوگیری از پاک شدن دسته‌بندی که دوره‌ها دارن

            // Indexes (برای بهبود سرعت جستجو)
            builder.HasIndex(x => x.Slug).IsUnique();
            builder.HasIndex(x => x.Title);
            builder.HasIndex(x => x.SiteSource);
        }
    }
}
