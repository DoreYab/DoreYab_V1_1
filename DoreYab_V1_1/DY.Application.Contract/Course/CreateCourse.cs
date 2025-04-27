namespace DY.Application.Contract.Course
{
    public class CreateCourse
    {
        public string Title { get; set; }
        public decimal? Price { get; set; }
        public string? Desctiption { get; set; }
        public string? CourseUrl { get; set; }
        public string SiteSource { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFree { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsFinished { get; set; }

        // seo
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeyword { get; set; }

        // Navigate
        public long CategoryId { get; set; }
    }
}
