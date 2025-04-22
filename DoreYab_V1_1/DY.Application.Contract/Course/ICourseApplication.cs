using DY.Application.Contract.CourseCategory;

namespace DY.Application.Contract.Course
{
    public interface ICourseApplication
    {
        Task<List<CourseViewModel>> List();
    }
}
