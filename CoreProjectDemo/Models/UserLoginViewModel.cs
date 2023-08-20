using System.ComponentModel.DataAnnotations;

namespace CoreProjectDemo.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adınızı giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string Password { get; set; }
    }
}
