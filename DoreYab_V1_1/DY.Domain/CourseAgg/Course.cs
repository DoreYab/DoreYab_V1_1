using _0_Framework.Domain;
using Domain.CourseCategory;


namespace DY.Domain.CourseAgg
{
    public class Course : EntityBase
    {
        public string Title { get; private set; }
        public decimal? Price { get; private set; }
        public string? Desctiption { get; private set; }
        public string? CourseUrl { get; private set; }
        public string SiteSource { get; private set; }
        public string Slug { get; private set; }
        public string ImageUrl { get; private set; }
        public bool IsFree { get; private set; }
        public bool IsDeleted { get; private set; }
        public bool IsFinished { get; private set; }

        // seo
        public string MetaTitle { get; private set; }
        public string MetaDescription { get; private set; }
        public string MetaKeyword { get; private set; }

        // Navigate
        public CourseCategory Category { get; set; }
        public long CategoryId { get; private set; }


        protected Course() { }

        public Course(string title, decimal? price, string? desctiption, string? courseUrl, string siteSource, string slug, string imageUrl, string metaTitle, string metaDescription, string metaKeyword, long categoryId)
        {
            Title = title;
            Price = price;
            Desctiption = desctiption;
            CourseUrl = courseUrl;
            SiteSource = siteSource;
            Slug = slug;
            ImageUrl = imageUrl;
            MetaTitle = metaTitle;
            MetaDescription = metaDescription;
            MetaKeyword = metaKeyword;
            IsDeleted = false;
            IsFree = true;
            IsFinished = true;
            CategoryId = categoryId;
        }
    }
}
