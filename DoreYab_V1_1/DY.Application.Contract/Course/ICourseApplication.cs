using DY.Application.Contract.CourseCategory;
using DY.Application.Contract.ViewModels.Course;


namespace DY.Application.Contract.Course
{
    public interface ICourseApplication
    {
        Task<IEnumerable<List_CourseVM>> GetList();
        Task<Create_CorceVM> CreatAsync(Create_CorceVM courseViewModel);
        Task<Update_CourseVM> UpdateAsync(long Id);
        Task<Update_CourseVM> GetByIdAsync(long Id);
    }
}
            