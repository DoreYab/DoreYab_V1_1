using DY.Application.Contract.CourseCategory;
using DY.Application.Contract.ViewModels;


namespace DY.Application.Contract.Course
{
    public interface ICourseApplication
    {
        Task<List<CourseViewModel>> GetList();
        Task<CourseViewModel> CreatAsync(CourseViewModel courseViewModel);
    }
}
        