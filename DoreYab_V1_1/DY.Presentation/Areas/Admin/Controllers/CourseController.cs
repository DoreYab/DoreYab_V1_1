using DY.Application.Contract.Course;
using DY.Application.Contract.CourseCategory;
using DY.Application.Contract.ViewModels;
using DY.Domain.CourseAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DY.Presentation.Area.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController(
        ICourseApplication courseApplication, 
        ICourseCategoryApplication courseCategoryApplication
        ) : Controller
    {


        private readonly ICourseApplication _courseApplication = courseApplication;
        public List<SelectListItem> CourseCategories { get; set; }
        private readonly ICourseCategoryApplication _courseCategoryApplication = courseCategoryApplication;

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CourseViewModel
            {
                CourseCategories = _courseCategoryApplication.List()
            .Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.Id.ToString()
            }).ToList()
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateCategoriesAsync(model);
                return View(model);
            }

            try
            {
                var result = await _courseApplication.CreatAsync(model);

                TempData["SuccessMessage"] = "Course created successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // این بخش فقط برای زمانی هست که متد application به جای استفاده از Result از throw استفاده کنه.
                TempData["ErrorMessage"] = "An error occurred while creating the course.";
                ModelState.AddModelError(string.Empty, ex.Message);
                await PopulateCategoriesAsync(model);
                return View(model);
            }
        }
        private async Task PopulateCategoriesAsync(CourseViewModel model)
        {
            // Updated to remove 'await' since List() is not asynchronous
            var categories = _courseCategoryApplication.List();
            model.CourseCategories = categories
                .Select(x => new SelectListItem
                {
                    Text = x.Title,
                    Value = x.Id.ToString()
                })
                .ToList();
        }

    }
}
