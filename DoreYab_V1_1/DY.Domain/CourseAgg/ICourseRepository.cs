using DY.Application.Contract.ViewModels;
using System.Linq.Expressions;

namespace DY.Domain.CourseAgg
{
    public interface ICourseRepository
    {
        Task CreateAsync(Course course);
        Task<List<CourseViewModel>> GetList();
        Task<bool> ExistsAsync(Expression<Func<Course, bool>> predicate);
        Task<Course> GetById(long Id);
        Task UpdateAsync(Course course);
    }
}
