using _0_Framework.Domain;
using DY.Domain.CourseAgg;

namespace DY.Domain.CourseCategoryAgg
{
    public class CourseCategory : EntityBase
    {
        public CourseCategory(string title)
        {
            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            //Courses = new List<Course>();
        }

        public string Title { get; private set; }
        public string? ShortDescription { get; private set; }
        public long CourseCount { get; private set; }
        public bool IsDeleted { get; private set; }

        public ICollection<Course> Courses { get; private set; }

        public void Rename(string title) => Title = title;

        public void Remove(long id) => IsDeleted = true;

        public void IsActivate(long id) => IsDeleted = false;
    }
}