using DY.Application.Contract.Course;
using DY.Application.Contract.CourseCategory;
using DY.Application.Contract.ViewModels.Course;
using DY.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DY.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public List<Create_CorceVM> courseViewModels { get; set; }
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseApplication _courseApplication;

        public HomeController(ILogger<HomeController> logger, ICourseApplication courseApplication)
        {
            _logger = logger;
            _courseApplication = courseApplication;
        }

        public async Task<IActionResult> Index()
        {
            courseViewModels = await _courseApplication.GetList();
            return View(courseViewModels); // ارسال لیست به View  
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
