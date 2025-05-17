using DY.Application.Contract.ViewModels;

namespace DY.Domain.CourseAgg
{
    public interface ICourseRepository
    {
        Task CreateAsync(Course course);
        Task<List<CourseViewModel>> GetList();
    }
}
