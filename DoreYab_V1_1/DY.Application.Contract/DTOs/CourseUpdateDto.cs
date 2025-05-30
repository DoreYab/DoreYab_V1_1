using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DY.Application.Contract.DTOs
{
    public class CourseUpdateDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public string CourseUrl { get; set; }
        public string SiteSource { get; set; }
        public string Slug { get; set; }
        public string? ImageUrl { get; set; } 
        public bool IsFree { get; set; }
        public bool IsFinished { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyword { get; set; }
        public long SelectedCategoryId { get; set; }
    }
}
