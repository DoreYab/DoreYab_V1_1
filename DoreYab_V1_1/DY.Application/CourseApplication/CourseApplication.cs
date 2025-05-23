using DY.Application.Contract.Course;
using DY.Application.Contract.ViewModels.Course;
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

        public async Task<Create_CorceVM> CreatAsync(Create_CorceVM courseViewModel)
        {
            try
            {
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

                var course = _mapper.Map<Course>(courseViewModel);
                await _courseRipository.CreateAsync(course);

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

        public Task<List<Create_CorceVM>> GetList()
        {
            return _courseRipository.GetList();
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
