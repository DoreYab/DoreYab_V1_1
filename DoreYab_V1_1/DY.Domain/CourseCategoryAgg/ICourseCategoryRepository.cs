
namespace DY.Domain.CourseCategoryAgg
{
    public interface ICourseCategoryRepository
    {
        void Add(CourseCategory entity);
        List<CourseCategory> GetAll();
        CourseCategory Get(long Id);
        void Save();

        bool Exsist(string title);
    }
}
