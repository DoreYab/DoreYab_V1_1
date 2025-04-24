using Domain.CourseCategory;
using DY.Domain.CourseAgg;
using DY.Inferastructure.EfCore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DY.Inferastructure.EfCore.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DoreYab_Context _context;

        public CourseRepository(DoreYab_Context context)
        {
            _context = context;
        }

        public async Task Addsynk(Course course)
        {
            await _context.Courses.AddAsync(course);
        }

        //public void Create(Course entity)
        //{
        //    _context.Courses.Add(entity);
        //    _context.SaveChanges();
        //}

        public async Task<List<Course>> GetAll()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
