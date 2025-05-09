using DY.Application.Contract.CourseCategory;
using DY.Domain.CourseCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DY.Domain.Services
{
    public interface ICourseCategoryValidatorServices
    {
        void CheckThisRecordAlreadyExsist(string title);
    }

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
