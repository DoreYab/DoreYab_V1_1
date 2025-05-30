using DY.Application.Contract.Course;
using DY.Application.Contract.DTOs;
using DY.Application.Contract.Service;
using DY.Application.Contract.ViewModels.Course;
using DY.Domain.CourseAgg;
using Mapster;
using MapsterMapper;

namespace DY.Application.CourseApplication
{
    public class CourseApplication : ICourseApplication
    {
        private readonly ICourseRepository _courseRipository;
        private readonly IfileService _fileService;
        private readonly IMapper _mapper;

        public CourseApplication(ICourseRepository courseRipository, IfileService fileService, IMapper mapper)
        {
            _courseRipository = courseRipository;
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task<Create_CorceVM> CreatAsync(Create_CorceVM courseViewModel)
        {
            try
            {
                var imageUrl = await _fileService.SaveFileAsync(courseViewModel.ImageFile, "courses");
                var thumbnailUrl = await _fileService.SaveThumbnailAsync(courseViewModel.ImageFile, "courses/thumbs");

                
                // بررسی تکراری بودن Slug
                var exists = await _courseRipository.ExistsAsync(c => c.Slug == courseViewModel.Slug);
                if (exists)
                {
                    return new Create_CorceVM
                    {
                        IsSucceeded = false,
                        Message = "این Slug قبلاً استفاده شده است.",
                    };
                }

                var courseDTO = _mapper.Map<CourseCreateDto>(courseViewModel);
                var course = _mapper.Map<Course>(courseDTO);

                course.SetImage(imageUrl, thumbnailUrl);

                await _courseRipository.SaveAsync(course);

                var result = _mapper.Map<Create_CorceVM>(course);
                result.IsSucceeded = true;
                result.Message = "Course created successfully.";
                return result;
            }
            catch (Exception ex)
            {
                return new Create_CorceVM
                {
                    IsSucceeded = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<bool> DeletAsync(long Id)
        {
            var course = await _courseRipository.SoftDeleteAsync(Id);
            if (course == false) 
            {
                return false; 
            }
            return true;
        }
        public async Task<bool> ActiveAsync(long Id)
        {
            var course = await _courseRipository.ActiveCourseAsync(Id);
            if (course == true)
            {
                return true;
            }
            return false;
        }

        public async Task<Update_CourseVM> GetByIdAsync(long Id)
        {
            try
            {
                var course = await _courseRipository.GetById(Id);

                if (course == null)
                {
                    return new Update_CourseVM
                    {
                        IsSucceeded = false,
                        Message = "Course not found."
                    };
                }

                var courseVM = _mapper.Map<Update_CourseVM>(course);

                courseVM.IsSucceeded = true;
                return courseVM;
            }
            catch (Exception ex)
            {
                return new Update_CourseVM
                {
                    IsSucceeded = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }

        public async Task<IEnumerable<List_CourseVM>> GetList()
        {
            var courses = await _courseRipository.GetList(); // خروجی: IEnumerable<Course>
            var result = courses.Adapt<IEnumerable<List_CourseVM>>(); // تبدیل با Mapster
            return result;
        }

        public async Task<Update_CourseVM> SaveUpdateAsync(Update_CourseVM model)
        {
            try
            {
                var existingCourse = await _courseRipository.GetById(model.Id);
                if (existingCourse == null)
                {
                    return new Update_CourseVM
                    {
                        IsSucceeded = false,
                        Message = "Course not found."
                    };
                }
                // اگر عکس جدید فرستاده شده
                if (model.ImageFile != null)
                {
                    // حذف تصاویر قبلی
                    _fileService.DeleteFile(existingCourse.ImageUrl);
                    _fileService.DeleteFile(existingCourse.ThumbnailUrl);

                    // ذخیره تصاویر جدید
                    var imageUrl = await _fileService.SaveFileAsync(model.ImageFile, "courses");
                    var thumbnailUrl = await _fileService.SaveThumbnailAsync(model.ImageFile, "courses/thumbs");

                    existingCourse.SetImage(imageUrl, thumbnailUrl);

                }
                var courseDTO = _mapper.Map<CourseUpdateDto>(existingCourse);
                var course = _mapper.Map<Course>(courseDTO);

                await _courseRipository.UpdateAsync(course);

                model.IsSucceeded = true;
                model.Message = "Course updated successfully.";
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در بروزرسانی دوره", ex);
            }
        }

        public async Task<Update_CourseVM> UpdateAsync(long Id)
        {
            Update_CourseVM courseVM = new Update_CourseVM();
            try
            {
              
                var course = await _courseRipository.GetById(Id);

                if (course == null)
                {
                    courseVM.IsSucceeded = false;
                    courseVM.Message = "Course not found.";
                    return courseVM;
                }
                courseVM = _mapper.Map<Update_CourseVM>(course);
                courseVM.IsSucceeded = true;
            }
            catch (Exception ex)
            {
                courseVM.IsSucceeded = false;
                courseVM.Message = $"An error occurred: {ex.Message}";
            }

            return courseVM;
        }


    }
}
