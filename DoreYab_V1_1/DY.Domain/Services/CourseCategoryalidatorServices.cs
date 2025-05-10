using DY.Domain.CourseCategoryAgg;

namespace DY.Domain.Services
{
    public class CourseCategoryalidatorServices : ICourseCategoryValidatorServices
    {
        private readonly ICourseCategoryRepository _categoryRepository;

        public CourseCategoryalidatorServices(ICourseCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void CheckThisRecordAlreadyExsist(string title)
        {
            if (_categoryRepository.Exsist(title))
                throw new Exception();
        }
    }
}
