using api.v1.service.main.Exceptions;
using api.v1.service.main.Helpers.Validators.Interfaces;
using System.Text.RegularExpressions;

namespace api.v1.service.main.Helpers.Validators
{
    public sealed class ValidateHelper : IUserValidateHelper
    {
        public void ValidateEmail(string email) =>
            Validate(@"^[\w]+\@[\-\w]+\.[\w]+$", email,
                     "Почта не валидная. Пример: ivanov@mail.ru");

        public void ValidatePassword(string password) => 
            Validate(@"^[\w]{8,}$", password, 
                     "Пароль не валидный. Разрешённые символы: буквы, цифры. Минимальная длина 8 символов");

        public void ValidateFullname(string fullname) => 
            Validate(@"^[А-Я]{1}[а-я]+ [А-Я]{1}[а-я]+$", fullname, 
                     "ФИО не валидное. Пример: Иванов Иван");

        private void Validate(string regex, string value, string error)
        {
            var rgx = new Regex(regex);
            if (!rgx.IsMatch(value))
            {
                throw new BadRequestException(error);
            }
        }
    }
}