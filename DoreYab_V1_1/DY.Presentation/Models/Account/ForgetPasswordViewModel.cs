using System.ComponentModel.DataAnnotations;

namespace DY.Presentation.Models.Account
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "لطفاً ایمیل خود را وارد کنید.")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نیست.")]
        public string Email { get; set; }
    }
}
