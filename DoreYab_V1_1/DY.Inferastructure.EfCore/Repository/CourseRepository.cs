using DY.Application.Contract.ViewModels;
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

        public async Task CreateAsync(Course course)
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

            var course = await _context.Courses.FindAsync(Id);

            return course ?? throw new InvalidOperationException($"Course with Id {Id} not found.");
        }

        Task<List<CourseViewModel>> ICourseRepository.GetList()
        {
            return _context.Courses.Include(x => x.Category)
                .Select(x => new CourseViewModel
                {
                    Title = x.Title,
                    Price = x.Price,
                    IsFree = x.IsFree,
                    ImageUrl = x.ImageUrl,
                    
                }).ToListAsync();
        }

        public async Task UpdateAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

    }
}
