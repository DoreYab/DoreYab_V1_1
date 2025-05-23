﻿using DY.Application.Contract.Course;
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
                    TempData["SuccessMessage"] = "Course created successfully.";
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    // Ensure result.Message is not null before passing it to AddModelError
                    ModelState.AddModelError(nameof(model.Slug), result.Message ?? "An error occurred.");
                    await PopulateCategoriesAsync(model);
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while creating the course.";
                ModelState.AddModelError(string.Empty, ex.Message);
                await PopulateCategoriesAsync(model);
                return View(model);
            }
        }

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

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return View(await _courseApplication.GetList());  
        }


        [HttpGet("Admin/Course/GetcourseEdit/{id}")]
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

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Update_CourseVM model)
        {
            return View(model);
        }

    }
}
