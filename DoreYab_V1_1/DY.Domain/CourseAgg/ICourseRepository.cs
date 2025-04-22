using Domain.CourseCategory;

namespace DY.Domain.CourseAgg
{
    public interface ICourseRepository
    {
        void Create(Course entity);
        Task<List<Course>> GetAll(); // Removed 'async' modifier and added missing semicolon
    }
}
