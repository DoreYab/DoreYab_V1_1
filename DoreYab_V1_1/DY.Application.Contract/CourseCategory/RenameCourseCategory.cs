namespace DY.Application.Contract.CourseCategory
{
    public class RenameCourseCategory : CreateCourseCategory
    {
        public long Id { get; set; }
        public long CourseCount { get; set; }
        public string? ShortDescription{ get; set; }
        public bool IsDeleted { get; set; }
    }
}
