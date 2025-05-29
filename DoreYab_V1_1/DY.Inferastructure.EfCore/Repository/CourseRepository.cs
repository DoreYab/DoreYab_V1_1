using DY.Application.Contract.ViewModels.Course;
using DY.Domain.CourseAgg;
using DY.Inferastructure.EfCore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;


namespace DY.Inferastructure.EfCore.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DoreYab_Context _context;

        public CourseRepository(DoreYab_Context context)
        {
            _context = context;
        }

        public async Task SaveAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistsAsync(Expression<Func<Course, bool>> predicate)
        {
            return await _context.Courses.AnyAsync(predicate);
        }

        public async Task<Course> GetById(long Id)
        {
            if (Id <= 0)
                throw new ArgumentException("Id must be greater than zero.", nameof(Id));
            var course = await _context.Courses.Include(a => a.Category).FirstOrDefaultAsync(a => a.Id.Equals(Id));
            //var course = await _context.Courses.FindAsync(Id);

            return course ?? throw new InvalidOperationException($"Course with Id {Id} not found.");
        }

       

        public async Task UpdateAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetList()
        {
            var model = await _context.Courses.AsNoTracking().ToListAsync();
            return model;
        }

        public async Task<bool> SoftDeleteAsync(long Id)
        {
            var course = await _context.Courses.FindAsync(Id);
            if (course == null)
                return false;

            course.SoftDelete();
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActiveCourseAsync(long Id)
        {
            var course = await _context.Courses.FindAsync(Id);
            if (course == null)
                return false;

            course.ActiveCourse();
            await _context.SaveChangesAsync();
            return true;
        }
    }
}   
