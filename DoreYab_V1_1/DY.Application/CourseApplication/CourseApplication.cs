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
            var course = _mapper.Map<Course>(courseViewModel);

             await _courseRipository.CreateAsync(course);

            var result = _mapper.Map<CourseViewModel>(course);

            return result;
        }

        

        public Task<List<CourseViewModel>> GetList()
        {
            return _courseRipository.GetList();
        }
    }
}
    