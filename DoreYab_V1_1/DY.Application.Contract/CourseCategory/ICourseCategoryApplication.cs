using System.Net.Sockets;

namespace DY.Application.Contract.CourseCategory
{
    public interface ICourseCategoryApplication
    {
        List<CourseCategoryViewModel> List();
        void Create(CreateCourseCategory category);
        void Rename(RenameCourseCategory command);
        RenameCourseCategory Get(long id);
        void Remove(long id);
        void Activate(long id); 
    }
}
