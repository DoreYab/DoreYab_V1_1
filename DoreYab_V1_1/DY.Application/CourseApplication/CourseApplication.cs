using DY.Application.Contract.Course;
using DY.Application.Contract.CourseCategory;
using DY.Domain.CourseAgg;
using DY.Domain.CourseCategoryAgg;

namespace DY.Application.CourseApplication
{
    public class CourseApplication : ICourseApplication
    {
        private readonly ICourseRepository _courseRipository;

        public CourseApplication(ICourseRepository courseRipository)
        {
            _courseRipository = courseRipository;
        }

        public void Create(CreateCourse command)
        {
            var course = new Course(command.Title,
                                    command.Price,
                                    command.CourseUrl,
                                    command.Desctiption,
                                    command.SiteSource,
                                    command.Slug,
                                    command.ImageUrl,
                                    command.IsFree,
                                    command.IsFinished,
                                    command.IsDeleted,
                                    command.MetaDescription,
                                    command.MetaTitle,
                                    command.MetaKeyword,
                                    command.CategoryId
                                    );
            _courseRipository.Create(course);
        }

        public Task<List<CourseViewModel>> GetList()
        {
            return _courseRipository.GetList();
        }
    }
}
    