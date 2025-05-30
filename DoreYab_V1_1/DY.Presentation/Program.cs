using DY.Application.Contract.Course;
using DY.Application.Contract.CourseCategory;
using DY.Application.CourseApplication;
using DY.Application.CourseCategory;
using DY.Domain.CourseAgg;
using DY.Domain.CourseCategoryAgg;
using DY.Domain.Services;
using DY.Inferastructure.EfCore.Data;
using DY.Inferastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using DY.Application.Mapper;
using Mapster;
using MapsterMapper;
using DY.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using DY.Application.Common.Interfaces;
using DY.Inferastructure.EfCore.Identity;
using DY.Application.Contract.Service;
using DY.Application.ImplimentServise;

namespace DY.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(typeof(CourseMappingConfig).Assembly);


            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews()
                            .AddDataAnnotationsLocalization()  // اضافه کردن پشتیبانی از Data Annotations
                            .AddViewLocalization();  // اضافه کردن پشتیبانی از محلی‌سازی برای View ها

            // Mapster
            builder.Services.AddSingleton(config);
            builder.Services.AddScoped<IMapper, ServiceMapper>();


            // FluentValidation
            //builder.Services.AddFluentValidationAutoValidation();
            //builder.Services.AddFluentValidationClientsideAdapters();
            //builder.Services.AddValidatorsFromAssemblyContaining<CreateCourseVM_Validator>();


            //DI
            builder.Services.AddTransient<ICourseCategoryRepository, CourseCategoryRepository>();
            builder.Services.AddTransient<ICourseCategoryApplication, CourseCategoryApplication>();
            builder.Services.AddTransient<ICourseCategoryValidatorServices, CourseCategoryalidatorServices>();

            builder.Services.AddTransient<ICourseRepository, CourseRepository>();
            builder.Services.AddTransient<ICourseApplication, CourseApplication>();

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            builder.Services.AddScoped<IfileService, FilseService>();

            builder.Services.AddDbContext<DoreYab_Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DoreYab_V1_1"));
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()    // Register Identity...
    .AddEntityFrameworkStores<DoreYab_Context>()
    .AddDefaultTokenProviders();



            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
