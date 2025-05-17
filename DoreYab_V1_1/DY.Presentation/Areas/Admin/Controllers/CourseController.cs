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
        public async Task<IActionResult> Create(CourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // 🔁 در صورت خطا باید مجدد دسته‌بندی‌ها لود شوند
                model.CourseCategories = _courseCategoryApplication.List()
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Title
                    }).ToList();

                return View(model);
            }

            await _courseApplication.CreatAsync(model);
            return RedirectToAction("Index");
        }
    }
}
