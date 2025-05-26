using DY.Application.Contract.Course;
using DY.Application.Contract.ViewModels.Course;
using DY.Domain.CourseAgg;
using Mapster;
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

        public Task<bool> DeletAsync(Update_CourseVM model)
        {
           
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

               
                _mapper.Map(model, existingCourse);

                await _courseRipository.UpdateAsync(existingCourse);

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
