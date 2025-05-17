using _0_Framework.Domain;
using DY.Domain.CourseAgg;
using DY.Domain.Services;

namespace DY.Domain.CourseCategoryAgg
{
    public class CourseCategory : EntityBase
    {
        private CourseCategory() { }
        public CourseCategory(string title, ICourseCategoryValidatorServices validatorServices)
        {
            GuardAgainstEmptyTitle(title);
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

        public void Rename(string title)
        {
            GuardAgainstEmptyTitle(title);
            Title = title;
        }

        public void Remove() => IsDeleted = true;

        public void IsActivate() => IsDeleted = false;

        public void GuardAgainstEmptyTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
        }
    }
}