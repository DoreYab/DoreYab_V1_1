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
        #region Creat Method GET and POST 
        [HttpGet]
        public IActionResult Create()
        {
            var model = new Create_CorceVM
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
                    TempData["SuccessMessage"] = "موردی که اضافه کرده بودی اضافه شد به درستی ";
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    // Ensure result.Message is not null before passing it to AddModelError
                    ModelState.AddModelError(nameof(model.Slug), result.Message ?? "نمیشه ساخت نمیدونم دلیلش چیه چک کن خودت ");
                    await PopulateCategoriesAsync(model);
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "رفتی تو اکسپشن ارور جلوشو گرفتم من، بگرد مشکل پیدا کن ";
                ModelState.AddModelError(string.Empty, ex.Message);
                await PopulateCategoriesAsync(model);
                return View(model);
            }
        }
        #endregion

        #region PopulateCategoriesAsync
        private async Task PopulateCategoriesAsync(Create_CorceVM model)
        {

            var categories = _courseCategoryApplication.List();
            model.CourseCategories = categories
                .Select(x => new SelectListItem
                {
                    Text = x.Title,
                    Value = x.Id.ToString(),
                    Selected = x.Id == model.SelectedCategoryId
                })
                .ToList();
        }
        private async Task PopulateCategoriesAsync(Update_CourseVM model)
        {

            var categories = _courseCategoryApplication.List();
            model.CourseCategories = categories
                .Select(x => new SelectListItem
                {
                    Text = x.Title,
                    Value = x.Id.ToString(),
                    Selected = x.Id == model.SelectedCategoryId
                })
                .ToList();
        }
        #endregion


        #region List Method for Course
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return View(await _courseApplication.GetList());
        }
        #endregion



        [HttpGet("Admin/Course/Edit/{id}")]
        public async Task<IActionResult> GetcourseEdit(long id)
        {
            var course = await _courseApplication.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            course.CourseCategories = _courseCategoryApplication.List()
                .Select(x => new SelectListItem
                {
                    Text = x.Title,
                    Value = x.Id.ToString(),
                    Selected = x.Id == course.SelectedCategoryId
                }).ToList();

            return View(course);
        }


        [HttpPost("Admin/Course/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostCourseEdit(long id, Update_CourseVM model)
        {
            if (!ModelState.IsValid)
            {   

                await PopulateCategoriesAsync(model);
                return View(model);
            }

            var result = await _courseApplication.SaveUpdateAsync(model);
            if (!result.IsSucceeded)
            {
                // Ensure result.Message is not null before passing it to AddModelError
                ModelState.AddModelError(string.Empty, result.Message ?? "نشد بروز رسانیش کنی   : ");


                await PopulateCategoriesAsync(model);
                return View(model);
            }

            return RedirectToAction(nameof(List));
        }


    }
}
