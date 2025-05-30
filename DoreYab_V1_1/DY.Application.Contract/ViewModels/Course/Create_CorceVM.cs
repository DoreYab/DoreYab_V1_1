using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DY.Application.Contract.ViewModels.Course
{
    public class Create_CorceVM
    {
        [Required(ErrorMessage = "عنوان دوره الزامی است.")]
        [StringLength(100, ErrorMessage = "عنوان دوره نباید بیشتر از 100 کاراکتر باشد.")]
        [Display(Name = "عنوان دوره")]
        public string Title { get; set; }

        [Range(0, 10000000, ErrorMessage = "قیمت باید عددی بین ۰ تا ۱۰٬۰۰۰٬۰۰۰ باشد.")]
        [Display(Name = "قیمت دوره")]
        public decimal? Price { get; set; }

        [StringLength(2000, ErrorMessage = "توضیحات نباید بیشتر از 2000 کاراکتر باشد.")]
        [Display(Name = "توضیحات دوره")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "لینک دوره الزامی است.")]
        [Url(ErrorMessage = "آدرس وارد شده معتبر نیست.")]
        [Display(Name = "لینک دوره")]
        public string CourseUrl { get; set; }

        [Required(ErrorMessage = "منبع سایت الزامی است.")]
        [StringLength(100, ErrorMessage = "منبع سایت نباید بیشتر از 100 کاراکتر باشد.")]
        [Display(Name = "منبع سایت")]
        public string SiteSource { get; set; }

        [Required(ErrorMessage = "اسلاگ الزامی است.")]
        [RegularExpression(@"^[a-z0-9-]+$", ErrorMessage = "اسلاگ فقط می‌تواند شامل حروف کوچک انگلیسی، اعداد و خط تیره باشد.")]
        [Display(Name = "اسلاگ (slug)")]
        public string Slug { get; set; }

        [Required(ErrorMessage = "آپلود تصویر الزامی است !")]
        [Display(Name = " تصویر")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "رایگان است؟")]
        public bool IsFree { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsDeleted { get; set; } = false;

        [Display(Name = "به پایان رسیده؟")]
        public bool IsFinished { get; set; }

        [StringLength(60, ErrorMessage = "Meta Title نباید بیشتر از 60 کاراکتر باشد.")]
        [Display(Name = "Meta Title")]
        public string MetaTitle { get; set; }

        [StringLength(160, ErrorMessage = "Meta Description نباید بیشتر از 160 کاراکتر باشد.")]
        [Display(Name = "Meta Description")]
        public string MetaDescription { get; set; }

        [StringLength(100, ErrorMessage = "Meta Keywords نباید بیشتر از 100 کاراکتر باشد.")]
        [Display(Name = "Meta Keywords")]
        public string MetaKeyword { get; set; }

        [Display(Name = "دسته‌بندی دوره‌ها")]
        public List<SelectListItem>? CourseCategories { get; set; }

        [Required(ErrorMessage = "انتخاب دسته‌بندی الزامی است.")]
        [Display(Name = "دسته‌بندی دوره")]
        public int SelectedCategoryId { get; set; }

        public bool IsSucceeded { get; set; }
        public string? Message { get; set; }
    }
}   
            