using DY.Domain.CourseCategoryAgg;
using DY.Domain.Exception;

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
                throw new DuplicatedRecordException("This record already exists in database");
        }
    }
}
