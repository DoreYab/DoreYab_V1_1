using DY.Application.Contract.ViewModels;
using DY.Domain.CourseAgg;
using Mapster;
using System;
using System.Collections.Generic;
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
                .Map(dest => dest.CreationDate, src => src.CreationDate.HasValue
                                                ? src.CreationDate.Value.ToString("yyyy/MM/dd")
                                                : string.Empty);

            // ViewModel → Entity (در صورت نیاز)
            config.NewConfig<CourseViewModel, Course>()
                .Ignore(dest => dest.Category) // Navigation property
                .Ignore(dest => dest.IsDeleted) // امنیت داده
                .Ignore(dest => dest.Id); // EntityBase مدیریت می‌کنه

        }
    }
}

