using DY.Application.Contract.ViewModels.Course;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DY.Application.Contract.Validators
{
    public class CreateCourseVM_Validator : AbstractValidator<Create_CorceVM>
    {
        public CreateCourseVM_Validator()
        {
            RuleFor(x => x.Title)
                 .NotEmpty().WithMessage("عنوان دوره نباید خالی باشد.")
                 .MaximumLength(200).WithMessage("عنوان دوره نباید بیشتر از 200 کاراکتر باشد.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("قیمت دوره نمی‌تواند منفی باشد.")
                .When(x => !x.IsFree); // اگر رایگان نیست، قیمت باید ≥ 0 باشد

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("توضیحات نباید بیشتر از 1000 کاراکتر باشد.")
                .When(x => !string.IsNullOrEmpty(x.Description));

            RuleFor(x => x.CourseUrl)
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                .WithMessage("آدرس دوره نامعتبر است.")
                .When(x => !string.IsNullOrEmpty(x.CourseUrl));

            RuleFor(x => x.SiteSource)
                .NotEmpty().WithMessage("نام سایت منبع نباید خالی باشد.")
                .MaximumLength(100).WithMessage("نام سایت منبع نباید بیشتر از 100 کاراکتر باشد.");

            RuleFor(x => x.Slug)
                .NotEmpty().WithMessage("اسلاگ نباید خالی باشد.")
                .Matches("^[a-z0-9-]+$").WithMessage("اسلاگ فقط می‌تواند شامل حروف کوچک، اعداد و خط تیره باشد.")
                .MaximumLength(100).WithMessage("اسلاگ نباید بیشتر از 100 کاراکتر باشد.");

            // Plan (pseudocode):
            // 1. The property ImageFile in Create_CorceVM is of type IFormFile, not string (not a URL).
            // 2. Validation should check that ImageFile is not null and is a valid image file (by extension or content type).
            // 3. Remove Uri.TryCreate check, as it is not applicable for IFormFile.
            // 4. Add NotNull() rule and a custom rule to check file extension or content type.

            //RuleFor(x => x.ImageFile)
            //    .NotNull().WithMessage("آپلود تصویر الزامی است !")
            //    .Must(file =>
            //    {
            //        if (file == null) return false;
            //        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            //        var fileName = file.FileName?.ToLowerInvariant();
            //        return allowedExtensions.Any(ext => fileName != null && fileName.EndsWith(ext));
            //    })
            //    .WithMessage("فرمت تصویر باید jpg، jpeg، png یا gif باشد.");

            RuleFor(x => x.MetaTitle)
                .NotEmpty().WithMessage("عنوان متا نباید خالی باشد.")
                .MaximumLength(150).WithMessage("عنوان متا نباید بیشتر از 150 کاراکتر باشد.");

            RuleFor(x => x.MetaDescription)
                .NotEmpty().WithMessage("توضیح متا نباید خالی باشد.")
                .MaximumLength(300).WithMessage("توضیح متا نباید بیشتر از 300 کاراکتر باشد.");

            RuleFor(x => x.MetaKeyword)
                .NotEmpty().WithMessage("کلمات کلیدی متا نباید خالی باشد.")
                .MaximumLength(200).WithMessage("کلمات کلیدی متا نباید بیشتر از 200 کاراکتر باشد.");

            
            
        }
    }
}
