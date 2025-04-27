using DY.Application.Contract.CourseCategory;
using Microsoft.AspNetCore.Mvc;

namespace DY.Presentation.Area.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public List<CourseCategoryViewModel> CourseCategories { get; set; }
        private readonly ICourseCategoryApplication _categoryApplication;

        public CategoryController(ICourseCategoryApplication categoryApplication)
        { 
            _categoryApplication = categoryApplication;
        }

        [HttpGet]
        public IActionResult List()
        {
            CourseCategories = _categoryApplication.List();
            return View(CourseCategories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(CreateCourseCategory command)
        {
            _categoryApplication.Create(command);
            return RedirectToAction("./List");
        }
    }
}
