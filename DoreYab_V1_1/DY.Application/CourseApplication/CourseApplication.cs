using DY.Application.Contract.Course;
using DY.Application.Contract.ViewModels;
using DY.Domain.CourseAgg;
using MapsterMapper;

namespace DY.Application.CourseApplication
{
    public class CourseApplication : ICourseApplication
    {
        private readonly ICourseRepository _courseRipository;
        private readonly IMapper _mapper;
        

        public CourseApplication(ICourseRepository courseRipository, IMapper mapper)
        {
            _courseRipository = courseRipository;
            _mapper = mapper;
        }

        public async Task<CourseViewModel> CreatAsync(CourseViewModel courseViewModel)
        {
            try
            {
                // بررسی تکراری بودن Slug
                var exists = await _courseRipository.ExistsAsync(c => c.Slug == courseViewModel.Slug);
                if (exists)
                {
                    return new CourseViewModel
                    {
                        IsSucceeded = false,
                        Message = "این Slug قبلاً استفاده شده است.",
                    };
                }

                var course = _mapper.Map<Course>(courseViewModel);
                await _courseRipository.CreateAsync(course);

                var result = _mapper.Map<CourseViewModel>(course);
                result.IsSucceeded = true;
                result.Message = "Course created successfully.";
                return result;
            }
            catch (Exception ex)
            {
                return new CourseViewModel
                {
                    IsSucceeded = false,
                    Message = ex.Message
                };
            }
        }

        public Task<List<CourseViewModel>> GetList()
        {
            return _courseRipository.GetList();
        }

        public async Task<CourseViewModel> UpdateAsync(CourseViewModel courseViewModel)
        {
            try
            {
                var course = _mapper.Map<Course>(courseViewModel);
                var model = await _courseRipository.GetById(course.Id);
                // بررسی تکراری بودن Slug
                var exists = await _courseRipository.ExistsAsync(c => c.Slug == courseViewModel.Slug);
                if (exists)
                {
                    return new CourseViewModel
                    {
                        IsSucceeded = false,
                        Message = "این Slug قبلاً استفاده شده است.",
                    };
                }

                await _courseRipository.UpdateAsync(model);

                var result = _mapper.Map<CourseViewModel>(model);
                result.IsSucceeded = true;
                result.Message = "Course UPdated successfully.";
                return result;
            }
            catch (Exception ex)
            {
                return new CourseViewModel
                {
                    IsSucceeded = false,
                    Message = ex.Message
                };
            }
        }
    }
}
    