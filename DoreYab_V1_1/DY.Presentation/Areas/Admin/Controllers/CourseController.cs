using DY.Application.Contract.Course;
using DY.Application.Contract.CourseCategory;
using DY.Domain.CourseAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DY.Presentation.Area.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly ICourseApplication _courseApplication;
        public List<SelectListItem> CourseCategories { get; set; }
        private readonly ICourseCategoryApplication _courseCategoryApplication;

        public CourseController(ICourseApplication courseApplication, ICourseCategoryApplication courseCategoryApplication)
        {
            _courseApplication = courseApplication;
            _courseCategoryApplication = courseCategoryApplication;
        }

        [HttpGet]
        public IActionResult Create()
        {
            CourseCategories = _courseCategoryApplication.List().Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.Id.ToString()
            }).ToList();
            return View(CourseCategories);
        }
        [HttpPost]
        public IActionResult Create(CreateCourse command)
        {
            _courseApplication.Create(command);
            return RedirectToAction("Index");
        }
    }
}
