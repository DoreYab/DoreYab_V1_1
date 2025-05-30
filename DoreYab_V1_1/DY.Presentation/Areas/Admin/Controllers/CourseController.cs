using DY.Application.Contract.Course;
using DY.Application.Contract.CourseCategory;
using DY.Application.Contract.ViewModels.Course;
using DY.Domain.CourseAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DY.Presentation.Area.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController(
                 ICourseApplication courseApplication,
                 ICourseCategoryApplication courseCategoryApplication,
                 ILogger<CourseController> logger) : Controller
    {

        private readonly ICourseApplication _courseApplication = courseApplication;
        private readonly ICourseCategoryApplication _courseCategoryApplication = courseCategoryApplication;
        private readonly ILogger<CourseController> _logger = logger;

        #region Create Course
        [HttpGet]
        public IActionResult Create()
        {
            var model = new Create_CorceVM
            {
                CourseCategories = GetCourseCategories()
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Create_CorceVM model)
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
                    TempData["SuccessMessage"] = "دوره با موفقیت اضافه شد.";
                    return RedirectToAction(nameof(List));
                }

                ModelState.AddModelError(nameof(model.Slug), result.Message ?? "خطای ناشناخته در ایجاد دوره.");
                await PopulateCategoriesAsync(model);
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in creating course.");
                TempData["ErrorMessage"] = "خطایی در ایجاد دوره رخ داد.";
                await PopulateCategoriesAsync(model);
                return View(model);
            }
        }
        #endregion

        #region List Courses
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var courses = await _courseApplication.GetList();
            return View(courses);
        }
        #endregion

        #region Edit Course
        [HttpGet("Admin/Course/Edit/{id}")]
        public async Task<IActionResult> Edit(long id)
        {
            var course = await _courseApplication.GetByIdAsync(id);
            if (course == null)
            {
                TempData["ErrorMessage"] = "دوره مورد نظر یافت نشد.";
                return RedirectToAction(nameof(List));
            }

            await PopulateCategoriesAsync(course);
            return View(course);
        }

        [HttpPost("Admin/Course/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Update_CourseVM model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateCategoriesAsync(model);
                return View(model);
            }

            var result = await _courseApplication.SaveUpdateAsync(model);
            if (!result.IsSucceeded)
            {
                ModelState.AddModelError(string.Empty, result.Message ?? "خطا در بروزرسانی.");
                await PopulateCategoriesAsync(model);
                return View(model);
            }

            TempData["SuccessMessage"] = "دوره با موفقیت ویرایش شد.";
            return RedirectToAction(nameof(List));
        }
        #endregion

        #region Delete Course (Soft Delete)
        [HttpPost("Admin/Course/Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id)
        {
            var success = await _courseApplication.DeletAsync(id);
            if (!success)
            {
                TempData["ErrorMessage"] = "حذف دوره با خطا مواجه شد.";
            }
            else
            {
                TempData["SuccessMessage"] = "دوره با موفقیت حذف شد.";
            }

            return RedirectToAction(nameof(List));
        }
        #endregion

        #region Activate Course
        [HttpPost("Admin/Course/Activate/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Activate(long id)
        {
            var success = await _courseApplication.ActiveAsync(id);
            if (!success)
            {
                TempData["ErrorMessage"] = "فعال‌سازی دوره با خطا مواجه شد.";
            }
            else
            {
                TempData["SuccessMessage"] = "دوره با موفقیت فعال شد.";
            }

            return RedirectToAction(nameof(List));
        }
        #endregion

        #region Helper Methods
        private List<SelectListItem> GetCourseCategories()
        {
            var categories = _courseCategoryApplication.List();
            return categories.Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.Id.ToString()
            }).ToList();
        }

        private async Task PopulateCategoriesAsync(Create_CorceVM model)
        {
            model.CourseCategories = GetCourseCategories()
                .Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value,
                    Selected = c.Value == model.SelectedCategoryId.ToString()
                }).ToList();
        }

        private async Task PopulateCategoriesAsync(Update_CourseVM model)
        {
            model.CourseCategories = GetCourseCategories()
                .Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value,
                    Selected = c.Value == model.SelectedCategoryId.ToString()
                }).ToList();
        }
        #endregion
    }
}
