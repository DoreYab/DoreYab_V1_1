using Domain.CourseCategory;

namespace DY.Domain.CourseAgg
{
    public interface ICourseRepository
    {
        Task Addsynk(Course course);
        Task SaveChangesAsync();
        Task<List<Course>> GetAll(); // Removed 'async' modifier and added missing semicolon
    }
}
