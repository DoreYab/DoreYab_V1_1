
using DY.Application.Contract.Course;

namespace DY.Domain.CourseAgg
{
    public interface ICourseRepository
    {
        void Create(Course course);
        Task<List<CourseViewModel>> GetList();
    }
}
