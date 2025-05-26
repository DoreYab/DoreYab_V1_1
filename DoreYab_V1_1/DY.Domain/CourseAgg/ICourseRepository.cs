using DY.Application.Contract.ViewModels.Course;
using System.Linq.Expressions;

namespace DY.Domain.CourseAgg
{
    public interface ICourseRepository
    {
        Task CreateAsync(Course course);
        Task<IEnumerable<Course>> GetList();
        Task<bool> ExistsAsync(Expression<Func<Course, bool>> predicate);
        Task<Course> GetById(long Id);
        Task UpdateAsync(Course course);
        Task<bool> SoftDeleteAsync(long Id);
    }
}   
