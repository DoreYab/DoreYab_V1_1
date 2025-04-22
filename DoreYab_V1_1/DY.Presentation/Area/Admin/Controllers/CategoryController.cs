using DY.Application.Contract.CourseCategory;
using Microsoft.AspNetCore.Mvc;

namespace DY.Presentation.Area.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public List<CourseCategoryViewModel> CourseCategories { get; set; }
        private readonly ICourseCategoryApplication _categoryApplication;

        public CategoryController(ICourseCategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        public IActionResult CategoryList()
        {
            CourseCategories = _categoryApplication.List();
            return View(CourseCategories);
        }
    }
}
