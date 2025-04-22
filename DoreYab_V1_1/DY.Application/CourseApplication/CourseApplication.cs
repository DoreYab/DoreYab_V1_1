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


        public async Task<List<CourseViewModel>> List()
        {
            var courseList = await _courseRipository.GetAll(); // Await the Task to get the actual list
            var result = new List<CourseViewModel>();

            foreach (var course in courseList) // Iterate over the resolved list
            {
                result.Add(new CourseViewModel
                {
                    Id = course.Id,
                    Title = course.Title,
                    Price = course.Price,
                    Desctiption = course.Desctiption,
                    CourseUrl = course.CourseUrl,
                    SiteSource = course.SiteSource,
                    Slug = course.Slug,
                    ImageUrl = course.ImageUrl,
                    IsFree = course.IsFree,
                    IsDeleted = course.IsDeleted,
                    IsFinished = course.IsFinished,
                    MetaTitle = course.MetaTitle,
                    MetaDescription = course.MetaDescription,
                    MetaKeyword = course.MetaKeyword,
                });
            }
            return result;
        }
    }
}
    