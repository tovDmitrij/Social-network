using System.ComponentModel.DataAnnotations;
namespace api.v1.service.auth.Models.Requests
{
    public sealed class SignUpRequestModel
    {
        [Required(ErrorMessage = "Введите почту", AllowEmptyStrings = false)]
        [RegularExpression(@"([\.\w]+)@(\w+)\.(\w+)", ErrorMessage = "Почта не валидная")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль", AllowEmptyStrings = false)]
        [RegularExpression(@"^(\w){8,16}$", ErrorMessage = "Пароль не валидный")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите фамилию", AllowEmptyStrings = false)]
        [RegularExpression(@"([A-ZА-Я][a-zа-я]+){3,32}", ErrorMessage = "Фамилия не валидная")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Введите имя", AllowEmptyStrings = false)]
        [RegularExpression(@"([A-ZА-Я][a-zа-я]+){3,32}", ErrorMessage = "Имя не валидное")]
        public string Name { get; set; }

        [RegularExpression(@"([A-ZА-Я][a-zа-я]+){3,32}", ErrorMessage = "Отчество не валидное")]
        public string? Patronymic { get; set; }
    }
}