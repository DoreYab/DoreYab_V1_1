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

        public CourseCategory Get(long id)
        {
            return _context.CourseCategories.FirstOrDefault(x=>x.Id == id);
        }

        public List<CourseCategory> GetAll()
        {
            return _context.CourseCategories.ToList();
        }

        public void Save()
        {
           _context.SaveChanges();
        }
    }
}
