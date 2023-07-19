using System.ComponentModel.DataAnnotations;
namespace api.v1.service.auth.Models.Requests
{
    public sealed class SignInRequestModel
    {
        [Required(ErrorMessage = "Введите почту", AllowEmptyStrings = false)]
        [RegularExpression(@"([\.\w]+)@(\w+)\.(\w+)", ErrorMessage = "Почта не валидная")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль", AllowEmptyStrings = false)]
        [RegularExpression(@"^(\w){8,16}$", ErrorMessage = "Пароль не валидный")]
        public string Password { get; set; }
    }
}