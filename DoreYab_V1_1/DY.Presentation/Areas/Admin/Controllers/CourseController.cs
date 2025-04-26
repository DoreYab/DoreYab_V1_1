using DY.Application.Contract.Course;
using DY.Domain.CourseAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DY.Presentation.Area.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        [HttpGet]
        public  IActionResult Create()
        {
            
                var model = new CourseViewModel();

                return View(model);
            

        }
        [HttpPost]
        public async Task<IActionResult> Create(CourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage); // یا breakpoint بزار اینجا
                }

                return View(model);
            }
            var course = new Course(
    model.Title,
    model.Price,
    model.Desctiption,
    model.CourseUrl,
    model.SiteSource,
    model.Slug,
    model.ImageUrl,
    model.IsFree, // اضافه شده
    model.IsFinished,
    model.MetaTitle,
    model.MetaDescription,
    model.MetaKeyword,
    model.CategoryId
);
            await _courseRepository.Addsynk(course);
            await _courseRepository.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
