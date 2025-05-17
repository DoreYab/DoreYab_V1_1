using Microsoft.AspNetCore.Mvc.Rendering;

namespace DY.Application.Contract.ViewModels
{
    public class CourseViewModel
    {
        
        public string Title { get; set; }
        public decimal? Price { get; set; }
        public string? Desctiption { get; set; }
        public string? CourseUrl { get; set; }
        public string SiteSource { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFree { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsFinished { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeyword { get; set; } 
        public string CreationDate { get; set; }
        public List<SelectListItem> CourseCategories { get; set; }


            
    }
}
            