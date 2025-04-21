using Domain.CourseCategory;

namespace DY.Domain.CourseCategoryAgg
{
    public interface ICourseCategoryRepository
    {
        void Create(CourseCategory entuty);
        List<CourseCategory> GetAll();
    }
}
