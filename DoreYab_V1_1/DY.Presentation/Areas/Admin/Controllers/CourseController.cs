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
        public List<SelectListItem> CourseCategories { get; set; }
        private readonly ICourseCategoryApplication _courseCategoryApplication;

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
    }
}
