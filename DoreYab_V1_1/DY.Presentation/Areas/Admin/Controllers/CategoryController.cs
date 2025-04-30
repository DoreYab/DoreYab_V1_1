using DY.Application.Contract.CourseCategory;
using Microsoft.AspNetCore.Mvc;

namespace DY.Presentation.Area.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
       
        public RenameCourseCategory RenameCategory { get; set; }
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
            return RedirectToAction("List");
        }

        [HttpGet("Edit/{id:long}")]
        public IActionResult Edit(long id)
        {
            var courseCategory = _categoryApplication.Get(id);
            return View(courseCategory);
        }

        [HttpPost("Edit")]
        public IActionResult Edit(RenameCourseCategory model)
        {
            if(!ModelState.IsValid)
                return View(model);

            _categoryApplication.Rename(model);
            return RedirectToAction("List");
        }
        
    }
}
