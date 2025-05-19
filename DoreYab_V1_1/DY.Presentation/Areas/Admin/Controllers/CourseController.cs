using DY.Application.Contract.Course;
using DY.Application.Contract.CourseCategory;
using DY.Application.Contract.ViewModels;
using DY.Domain.CourseAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DY.Presentation.Area.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly ICourseApplication _courseApplication;
        private readonly ICourseCategoryApplication _courseCategoryApplication;
        private readonly ILogger<CourseController> _logger;

        public CourseController(
            ICourseApplication courseApplication,
            ICourseCategoryApplication courseCategoryApplication,
            ILogger<CourseController> logger)
        {
            _courseApplication = courseApplication;
            _courseCategoryApplication = courseCategoryApplication;
            _logger = logger;
        }

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

                if (result.IsSucceeded)
                {

                    TempData["SuccessMessage"] = "Course created successfully.";
                    return Redirect("/");
                }
                else
                {

                    ModelState.AddModelError(nameof(model.Slug), result.Message);
                    await PopulateCategoriesAsync(model);
                    return View(model);
                }
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
            // نیازی به await نیست چون List() آسنکرون نیست
            var categories = _courseCategoryApplication.List();
            model.CourseCategories = categories
                .Select(x => new SelectListItem
                {
                    Text = x.Title,
                    Value = x.Id.ToString(),
                    Selected = x.Id == model.SelectedCategoryId // اضافه کردن Selected
                })
                .ToList();
        }

    }
}
