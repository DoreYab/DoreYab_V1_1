using Domain.CourseCategory;
using DY.Domain.CourseCategoryAgg;
using DY.Inferastructure.EfCore.Data;

namespace DY.Inferastructure.EfCore.Repository
{
    public class CourseCategoryRepository : ICourseCategoryRepository
    {
        private readonly DoreYab_Context _context;
        public CourseCategoryRepository(DoreYab_Context context)
        {
            _context = context;
        }

        public void Add(CourseCategory entity)
        {
            _context.CourseCategories.Add(entity);
            _context.SaveChanges();
        }

        public List<CourseCategory> GetAll()
        {
            return _context.CourseCategories.ToList();
        }
    }
}
