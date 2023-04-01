using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using database.context.Repos.Profile;
using database.context.Models.Profile.Languages;
using database.context.Repos.Languages;
namespace api.Controllers
{
    /// <summary>
    /// Взаимодействие с профилем пользователей
    /// </summary>
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public sealed class ProfileController : ControllerBase
    {
        private readonly IProfileRepos _profile;
        private readonly ILanguageRepos _language;

        public ProfileController(IProfileRepos profile, ILanguageRepos language)
        {
            _profile = profile;
            _language = language;
        }



        #region GET

        /// <summary>
        /// Получить базовую информацию о профиле пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("Base/{userID:int}")]
        public IActionResult GetBaseProfileInfo(int userID)
        {
            switch (!_profile.IsUserExist(userID))
            {
                case true:
                    return StatusCode(404,
                    new
                    {
                        status = "Пользователя с заданным идентификатором не существует"
                    });
                case false:
                    return StatusCode(200,
                        new
                        {
                            status = "Пользователь успешно найден",
                            user = _profile.GetProfileBaseInfo(userID)
                        });
            }
        }

        /// <summary>
        /// Получить список языков пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("Languages/{userID:int}")]
        public IActionResult GetLanguageList(int userID)
        {
            switch (!_profile.IsUserExist(userID))
            {
                case true:
                    return StatusCode(404,
                        new 
                        {
                            status = "Пользователя с заданным идентификатором не существует"
                        });
                case false:
                    IEnumerable<ProfileLanguageInfoModel>? languages = _profile.GetLanguages(userID);

                    switch (languages.Any())
                    { 
                        case true:
                            return StatusCode(200,
                                new 
                                {
                                    status = "Список языков пользователя успешно сформирован",
                                    languages
                                });
                        case false:
                            return StatusCode(404,
                                new 
                                {
                                    status = "У пользователя отсутствует список языков"
                                });
                    }
            }
        }

        #endregion



        #region POST

        [HttpPost("Languages")]
        public IActionResult AddLanguage(int userID, int languageID)
        {
            if (!_profile.IsUserExist(userID))
            {
                return StatusCode(404,
                    new
                    {
                        status = "Пользователь с заданным идентификатором не найден"
                    });
            }
            if (!_language.IsLanguageExist(languageID))
            {
                return StatusCode(404,
                    new
                    {
                        status = "Язык с заданным идентификатором не найден"
                    });
            }
            if (_profile.IsLanguageAdded(userID, languageID))
            {
                return StatusCode(406,
                    new
                    {
                        status = "Язык уже добавлен в список языков пользователя"
                    });
            }

            _profile.AddLanguage(userID, languageID);
            return StatusCode(200,
                new
                {
                    status = "Новый язык был успешно добавлен в профиль пользователя"
                });
        }

        #endregion



        #region DELETE

        [HttpDelete("Languages")]
        public IActionResult RemoveLanguage(int userID, int languageID)
        {
            if (!_profile.IsUserExist(userID))
            {
                return StatusCode(404,
                    new
                    {
                        status = "Пользователь с заданным идентификатором не найден"
                    });
            }
            if (!_language.IsLanguageExist(languageID))
            {
                return StatusCode(404,
                    new
                    {
                        status = "Языка с заданным идентификатором не существует в системе"
                    });
            }
            if (!_profile.IsLanguageAdded(userID, languageID))
            {
                return StatusCode(406,
                    new
                    {
                        status = "Языка нет в списке языков пользователя"
                    });
            }

            _profile.RemoveLanguage(userID, languageID);
            return StatusCode(200,
                new
                {
                    status = "Удаление языка из профиля пользователя прошло успешно"
                });
        }

        #endregion



    }
}