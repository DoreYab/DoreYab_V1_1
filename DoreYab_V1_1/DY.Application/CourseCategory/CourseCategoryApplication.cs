using DY.Application.Contract.CourseCategory;
using DY.Domain.CourseCategoryAgg;
using System.Reflection.Metadata.Ecma335;

namespace DY.Application.CourseCategory
{
    public class CourseCategoryApplication : ICourseCategoryApplication
    {
        private readonly ICourseCategoryRepository _categoryRepository;

        public CourseCategoryApplication(ICourseCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<CourseCategoryViewModel> GetAll()
        {
            var courseCategories = _categoryRepository.GetAll();
            var result = new List<CourseCategoryViewModel>();

            foreach (var courseCategory in courseCategories)
            {
                result.Add(new CourseCategoryViewModel
                {
                    Id = courseCategory.Id,
                    Title = courseCategory.Title,
                    IsDeleted = courseCategory.IsDeleted,
                    ShortDescription = courseCategory.ShortDescription,
                    CreationDate = courseCategory.CreationDate,
                });
            }
            return result;
        }
        
        
       
    }
}