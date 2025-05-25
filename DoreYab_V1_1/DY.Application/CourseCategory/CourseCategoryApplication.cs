using DY.Domain.CourseCategoryAgg;
using DY.Application.Contract.CourseCategory;
using DY.Domain.Services;

namespace DY.Application.CourseCategory
{
    public class CourseCategoryApplication : ICourseCategoryApplication
    {
        private readonly ICourseCategoryRepository _categoryRepository;
        private readonly ICourseCategoryValidatorServices _validatorServices;

        public CourseCategoryApplication(ICourseCategoryRepository categoryRepository,
            ICourseCategoryValidatorServices validatorServices)
        {
            _categoryRepository = categoryRepository;
            _validatorServices = validatorServices;
        }



        public void Create(CreateCourseCategory category)
        {
            var courseCategory = new Domain.CourseCategoryAgg.CourseCategory(category.Title, _validatorServices);
            _categoryRepository.Add(courseCategory);
        }

        public RenameCourseCategory Get(long id)
        {
            var courseCategory = _categoryRepository.Get(id);
            return new RenameCourseCategory
            {
                Id = courseCategory.Id,
                Title = courseCategory.Title,
                CourseCount = courseCategory.CourseCount,
                ShortDescription = courseCategory.ShortDescription,
                IsDeleted = courseCategory.IsDeleted,
            };
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

<<<<<<< Updated upstream
        public void Remove(long id)
        {
            var courseCategory = _categoryRepository.Get(id);
            courseCategory.Remove();
            _categoryRepository.Save();
        }

        public void Rename(RenameCourseCategory command)
        {
            var courseCategory = _categoryRepository.Get(command.Id);
            courseCategory.Rename(command.Title);
            _categoryRepository.Save();
        }

        public void Activate(long id)
        {
            var courseCategory = _categoryRepository.Get(id);
            courseCategory.IsActivate();
            _categoryRepository.Save();
        }
    }
}