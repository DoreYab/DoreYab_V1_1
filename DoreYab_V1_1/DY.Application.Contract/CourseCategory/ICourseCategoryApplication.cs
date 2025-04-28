namespace DY.Application.Contract.CourseCategory
{
    public interface ICourseCategoryApplication
    {
        List<CourseCategoryViewModel> List();
        void Create(CreateCourseCategory category);
        void Rename(RenameCourseCategory command);
    }
}
    