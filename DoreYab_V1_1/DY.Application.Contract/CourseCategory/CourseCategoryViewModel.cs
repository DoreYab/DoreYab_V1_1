using _0_Framework.Domain;

namespace DY.Application.Contract.CourseCategory
{
    public class CourseCategoryViewModel : EntityBase
    {
        public string Title { get; set; } 
        public string? ShortDescription { get; set; }
        public long CourseCount { get; set; }
        public bool IsDeleted { get; set; }

        public CourseCategoryViewModel(string title, string? shortDescription, long courseCount)
        {
            Title = title;
            ShortDescription = shortDescription;
            CourseCount = courseCount;
            IsDeleted = false;
            CreationDate = DateTime.UtcNow;
        }

        public CourseCategoryViewModel() { }
    }
}
