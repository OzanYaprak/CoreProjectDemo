using System.ComponentModel.DataAnnotations;

namespace CoreProjectDemo.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="Lütfen isim giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyisim giriniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen kulanıcı adı giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen mail giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifre giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz")]
        [Compare("Password",ErrorMessage ="Lütfen şifrelerin eşleştiğinden emin olun")]
        public string ConfirmPassword { get; set; }
    }
}
