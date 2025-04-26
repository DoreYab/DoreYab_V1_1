using DY.Domain.CourseCategoryAgg;

namespace DY.Domain.CourseCategoryAgg
{
    public interface ICourseCategoryRepository
    {
        void Add(CourseCategory entity);
        List<CourseCategory> GetAll();
    }
}
