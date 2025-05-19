using DY.Application.Contract.ViewModels;
using DY.Domain.CourseAgg;
using Mapster;

namespace DY.Application.Mapper
{
    public class CourseMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Entity → ViewModel
            config.NewConfig<Course, CourseViewModel>()
                .Map(dest => dest.SelectedCategoryId, src => (int)src.CategoryId)
                .Map(dest => dest.IsSucceeded, src => true) // برای برگشت موفقیت آمیز
                .Map(dest => dest.Message, src => "Course created successfully");

            // ViewModel → Entity (با استفاده از کانستراکتور)
            config.NewConfig<CourseViewModel, Course>()
                    .ConstructUsing(src => new Course(
                        src.Title,
                        src.Price,
                        src.Description,
                        src.CourseUrl, // حذف ! چون الان Required هست
                        src.SiteSource,
                        src.Slug,
                        src.ImageUrl,
                        src.IsFree,
                        src.IsFinished,
                        src.MetaTitle ?? string.Empty,
                        src.MetaDescription ?? string.Empty,
                        src.MetaKeyword ?? string.Empty,
                        src.SelectedCategoryId
                    ));

        }
    }
}

