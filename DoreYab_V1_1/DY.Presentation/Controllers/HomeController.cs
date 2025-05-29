using DY.Application.Contract.Course;
using DY.Application.Contract.CourseCategory;
using DY.Application.Contract.ViewModels.Course;
using DY.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DY.Presentation.Controllers
{
    public class HomeController(ILogger<HomeController> logger, ICourseApplication courseApplication) : Controller
    {
        public required IEnumerable<List_CourseVM> ListCourseVMs { get; set; }
        private readonly ILogger<HomeController> _logger = logger;
        private readonly ICourseApplication _courseApplication = courseApplication;

        public async Task<IActionResult> Index()
        {
            // Get all courses
            var allCourses = await _courseApplication.GetList();
            // Filter out deleted courses
            ListCourseVMs = allCourses.Where(x => !x.IsDeleted).ToList();
            return View(ListCourseVMs);
        }

        #region Exm  
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
