using _0_Framework.Domain;
using DY.Domain.CourseCategoryAgg;


namespace DY.Domain.CourseAgg
{
    public class Course : EntityBase
    {
        public string Title { get; private set; }
        public decimal? Price { get; private set; }
        public string? Description { get; private set; }

        public string CourseUrl { get; private set; }
        public string SiteSource { get; private set; }
        public string Slug { get; private set; }
        public string ImageUrl { get; private set; }
        public bool IsFree { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        public bool IsFinished { get; private set; }

        // seo
        public string MetaTitle { get; private set; }
        public string MetaDescription { get; private set; }
        public string MetaKeyword { get; private set; }

        // Navigate
        public CourseCategory Category { get; set; }
        public long CategoryId { get; private set; }


        protected Course() { }

        public Course(

                        string title,
                        decimal? price,
                        string? description,

                        string courseUrl,
                        string siteSource,
                        string slug,
                        //string imageUrl,

                        bool isFree,
                        bool isFinished,

                        string metaTitle,
                        string metaDescription,
                        string metaKeyword,

                        long categoryId
            )
        {

            Title = title ?? throw new ArgumentNullException(nameof(title));
            Price = price;
            Description = description;
            CourseUrl = courseUrl ?? throw new ArgumentNullException(nameof(courseUrl));
            SiteSource = siteSource ?? throw new ArgumentNullException(nameof(siteSource));
            Slug = slug ?? throw new ArgumentNullException(nameof(slug));
            //ImageUrl = imageUrl ?? throw new ArgumentNullException(nameof(imageUrl));
            IsFree = isFree;
            IsFinished = isFinished;

            MetaTitle = metaTitle ?? string.Empty;
            MetaDescription = metaDescription ?? string.Empty;
            MetaKeyword = metaKeyword ?? string.Empty;

            CategoryId = categoryId;
        }

        public void SoftDelete()
        {
            if (IsDeleted)
                throw new InvalidOperationException("Course is already deleted.");

            IsDeleted = true;
        }
        public void ActiveCourse()
        {
            if (!IsDeleted)
                throw new InvalidOperationException("Course is already Actived.");

            IsDeleted = false;
        }


    }
}
