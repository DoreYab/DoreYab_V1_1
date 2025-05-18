using DY.Application.Contract.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DY.Application.Contract.Validators
{
    public class CreateCourseVM_Validator : AbstractValidator<CourseViewModel>
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

            RuleFor(x => x.ImageUrl)
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                .WithMessage("آدرس تصویر نامعتبر است.")
                .When(x => !string.IsNullOrEmpty(x.ImageUrl));

            RuleFor(x => x.MetaTitle)
                .NotEmpty().WithMessage("عنوان متا نباید خالی باشد.")
                .MaximumLength(150).WithMessage("عنوان متا نباید بیشتر از 150 کاراکتر باشد.");

            RuleFor(x => x.MetaDescription)
                .NotEmpty().WithMessage("توضیح متا نباید خالی باشد.")
                .MaximumLength(300).WithMessage("توضیح متا نباید بیشتر از 300 کاراکتر باشد.");

            RuleFor(x => x.MetaKeyword)
                .NotEmpty().WithMessage("کلمات کلیدی متا نباید خالی باشد.")
                .MaximumLength(200).WithMessage("کلمات کلیدی متا نباید بیشتر از 200 کاراکتر باشد.");

            RuleFor(x => x.CreationDate)
                .NotEmpty().WithMessage("تاریخ ایجاد نباید خالی باشد.")
                .Must(date => DateTime.TryParse(date, out _))
                .WithMessage("فرمت تاریخ ایجاد نامعتبر است.");

            
        }
    }
}
