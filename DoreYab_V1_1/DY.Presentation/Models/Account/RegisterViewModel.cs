using System.ComponentModel.DataAnnotations;

namespace DY.Presentation.Models.Account
{
    public class RegisterViewModel
    {
        [Required, Display(Name ="نام و نام خانوادگی")]
        public string FullName { get; set; }

        [Required, EmailAddress, Display(Name ="ایمیل")]
        public string Email { get; set; }

        [Required, DataType(DataType.Password), Display(Name ="رمز عبور")]
        public string Password { get; set; }
    }
}
