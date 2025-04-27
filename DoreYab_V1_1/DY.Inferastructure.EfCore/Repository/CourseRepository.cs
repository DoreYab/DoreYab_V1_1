
using DY.Application.Contract.Course;
using DY.Domain.CourseAgg;
using DY.Inferastructure.EfCore.Data;
using Microsoft.EntityFrameworkCore;
using System;


namespace DY.Inferastructure.EfCore.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DoreYab_Context _context;

        public CourseRepository(DoreYab_Context context)
        {
            _context = context;
        }

        

        public void Create(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        

        Task<List<CourseViewModel>> ICourseRepository.GetList()
        {
            return _context.Courses.Include(x => x.Category)
                .Select(x => new CourseViewModel
                {
                Id = x.Id,
                    Title = x.Title,
                    Price = x.Price,
                    IsFree = x.IsFree,
                    ImageUrl = x.ImageUrl,
                    CourseCategory = x.Category.Title,
                    CategoryId = x.CategoryId,
                }).ToListAsync();
        }
    }
}
