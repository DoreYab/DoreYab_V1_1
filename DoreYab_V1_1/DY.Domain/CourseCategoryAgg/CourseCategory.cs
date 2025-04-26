using _0_Framework.Domain;
using DY.Domain.CourseAgg;

namespace Domain.CourseCategory
{
    public class CourseCategory : EntityBase
    {
        public CourseCategory(string title)
        {
            Title = title;
            IsDeleted = false;
            Courses = new List<Course>();
        }

        public string Title { get; private set; }
        public string? ShortDescription { get; private set; }
        public long CourseCount { get; private set; }
        public bool IsDeleted { get; private set; }

        public ICollection<Course> Courses { get; private set; }
    }
}
