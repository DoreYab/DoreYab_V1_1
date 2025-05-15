using DY.Application.Contract.CourseCategory;
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
}
