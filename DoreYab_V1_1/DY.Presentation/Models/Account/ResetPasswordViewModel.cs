using System.ComponentModel.DataAnnotations;

namespace DY.Presentation.Models.Account
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage ="وارد کردن ایمیل الزامیست")]
        [EmailAddress(ErrorMessage ="ایمیل معتبر نیست")]
        public string Email { get; set; }

        [Required(ErrorMessage ="رمز عبور جدید را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
