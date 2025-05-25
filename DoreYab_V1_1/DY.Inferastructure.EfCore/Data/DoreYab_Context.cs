using DY.Domain.CourseCategoryAgg;
using DY.Domain.CourseAgg;
using DY.Inferastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;
using DY.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace DY.Inferastructure.EfCore.Data
{
    public class DoreYab_Context : IdentityDbContext<ApplicationUser>
    {
        public DbSet<CourseCategory> CourseCategories{ get; set; }
        public DbSet<Course> Courses{ get; set; }

        public DoreYab_Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CourseCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
        }
    }
}
