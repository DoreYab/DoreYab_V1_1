using DY.Application.Contract.CourseCategory;
using DY.Application.CourseCategory;
using DY.Domain.CourseCategoryAgg;
using DY.Inferastructure.EfCore.Data;
using DY.Inferastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;

namespace DY.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<ICourseCategoryRepository, CourseCategoryRepository>();
            builder.Services.AddTransient<ICourseCategoryApplication, CourseCategoryApplication>();

            builder.Services.AddDbContext<DoreYab_Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DoreYab_V1_1"));
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
