using DY.Domain.CourseCategoryAgg;
using DY.Application.Contract.CourseCategory;

namespace DY.Application.CourseCategory
{
    public class CourseCategoryApplication : ICourseCategoryApplication
    {
        private readonly ICourseCategoryRepository _categoryRepository;

        public CourseCategoryApplication(ICourseCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Create(CreateCourseCategory category)
        {
            var courseCategory = new DY.Domain.CourseCategoryAgg.CourseCategory(category.Title);
            _categoryRepository.Add(courseCategory);
        }

        public List<CourseCategoryViewModel> List()
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