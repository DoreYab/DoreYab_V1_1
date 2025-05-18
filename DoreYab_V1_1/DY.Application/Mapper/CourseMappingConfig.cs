using DY.Application.Contract.ViewModels;
using DY.Domain.CourseAgg;
using Mapster;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DY.Application.Mapper
{
    public class CourseMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Entity → ViewModel
            config.NewConfig<Course, CourseViewModel>()
                .Map(dest => dest.SelectedCategoryId, src => (int)src.CategoryId)
                .Map(dest => dest.CreationDate, src => src.CreationDate.HasValue
                                                    ? src.CreationDate.Value.ToString("yyyy/MM/dd")
                                                    : string.Empty);

            // ViewModel → Entity (با استفاده از کانستراکتور)
            config.NewConfig<CourseViewModel, Course>()
                    .ConstructUsing(src => new Course(
                        src.Title,
                        src.Price,
                        src.Description,
                        src.CourseUrl!,
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

